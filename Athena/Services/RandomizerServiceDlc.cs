// SPDX-License-Identifier: GPL-3.0-only
using Athena.Config;
using Athena.Models;
using Athena.Utilities;
using DotNext.Runtime.CompilerServices;
using EldenRingParamsEditor;
using SoulsFormats;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Windows.Documents;
using UniversalReplacementRandomizer;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static SoulsFormats.MSB2.Event;
using static SoulsFormats.MSBVD.Event.Light.LightConfig.UnkBloomConfig;

namespace Athena.Services;

public enum DlcMode
{
    Default,
    Moonwalk,
    Omenveil,
    Anamnesis
}

public class RandomizerServiceDlc
{
    private string SeedManagerPrefix;
    private const int StarlightShopMenuTextId = 508000;

    private RandomizerServiceStartingClass randomizerServiceStartingClass = new();
    RandomizerServiceStartingClass.ClassStatAllocation startingStats;
    private int[] anamnesisStarlightWeapons;


    public RandomizerServiceDlc(string appVersion)
    {
        SeedManagerPrefix = "dlc" + appVersion;
        startingStats = new(Stats: new int[] { 50, 10, 10, 10, 10, 10, 10, 10 });
        anamnesisStarlightWeapons = new int[] { 0, 0, 0, 0 };
    }

    public void RandomizeDlc(int? baseSeed,
                             DlcMode mode,
                             Action<int?>? updateBaseSeedCallback,
                             Action<int?>? updateRandomizedSeedCallback,
                             Action<DlcMode?>? updateRandomizedModeDlcCallback)
    {
        using DebugTimer _ = new DebugTimer("RandomizeDlc");
        //SimulationUtils.SimulateDlcToFile(10_000);

        var editor = ParamsEditor.ReadFromRegulationPath(Constants.RegulationInDlc);

        //MetadataUtils.GenerateWeaponsMappings(editor);
        //MetadataUtils.GenerateSpellsMappings(editor);

        string seedManagerPrefix;
        string randomizationGroupsDirPath;

        switch (mode)
        {
            case DlcMode.Moonwalk:
                {
                    seedManagerPrefix = SeedManagerPrefix + "_moonwalk";
                    randomizationGroupsDirPath = $"{Constants.RandomizationGroupsDlc}/moonwalk";
                    break;
                }
            case DlcMode.Omenveil:
                {
                    seedManagerPrefix = SeedManagerPrefix + "_omenveil";
                    randomizationGroupsDirPath = $"{Constants.RandomizationGroupsDlc}/omenveil";
                    break;
                }
            case DlcMode.Anamnesis:
                {
                    seedManagerPrefix = SeedManagerPrefix + "_anamnesis";
                    randomizationGroupsDirPath = $"{Constants.RandomizationGroupsDlc}/anamnesis";
                    break;
                }
            default:
                {
                    seedManagerPrefix = SeedManagerPrefix;
                    randomizationGroupsDirPath = $"{Constants.RandomizationGroupsDlc}/default";
                    break;
                }
        }

        var urr = new OptimizedReplacementRandomizer(seedManagerPrefix, baseSeed);
        if (baseSeed == null)
        {
            updateBaseSeedCallback?.Invoke(urr.GetBaseSeed());
        }

        InitStartingClassesDlc(editor, mode);

        InitDlcShop(editor, urr, mode);

        InitAnamnesisRemembrances(editor, urr);
        
        Dictionary<int, List<ItemLotEntry>> weaponIdsToItemLotMap = editor.GetWeaponIdsToItemLotMap();
        Dictionary<int, List<ItemLotEntry>> weaponIdsToItemLotEnemy = editor.GetWeaponIdsToItemLotEnemy();
        Dictionary<int, List<int>> weaponIdsToShopLineup = editor.GetWeaponIdsToShopLineup();

        ReplacementUtils.Randomize<GameItemModel>(editor,
                                                  urr,
                                                  randomizationGroupsDirPath,
                                                  weaponIdsToItemLotMap,
                                                  weaponIdsToItemLotEnemy,
                                                  weaponIdsToShopLineup);

        // Equip Millicent's Armor
        EquipMillicentsArmor(editor, mode);

        // Disable Upgrading the default club
        DisableUpgradingClub(editor);

        ModeCustomization(mode);

        editor.WriteToRegulationPath(Constants.RegulationOutDlc);

        updateRandomizedSeedCallback?.Invoke(urr.GetBaseSeed());
        updateRandomizedModeDlcCallback?.Invoke(mode);
    }

    private void InitStartingClassesDlc(ParamsEditor editor, DlcMode mode = DlcMode.Default)
    {
        using DebugTimer _ = new DebugTimer("InitStartingClassesDlc");

        int NumberOfStartingRunes = 100_000;

        int ClubItemId = 11010000;
        int GlintstoneStaffItemId;
        int FingerSealItemId = Constants.FingerSealItemId + 25;

        switch (mode)
        {
            case DlcMode.Moonwalk:
                {
                    // Custom Carian Sorcery Sword (has no ash of war, does 0 damage with regular attacks)
                    GlintstoneStaffItemId = 70000000 + 25;
                    break;
                }
            case DlcMode.Omenveil:
                {
                    // default
                    GlintstoneStaffItemId = Constants.GlintstoneStaffItemId + 25;
                    // Custom Crucible Seal (no stats requirement, otherwise indistinguishable from erdtree seal)
                    FingerSealItemId = 70010000 + 10;
                    break;
                }
            case DlcMode.Anamnesis:
                {
                    // default
                    GlintstoneStaffItemId = 33090000 + 10; //Carian Regal Scepter
                    startingStats = new(Stats: new int[] { 40, 10, 10, 10, 10, 10, 10, 10 });
                    break;
                }
            default:
                {
                    GlintstoneStaffItemId = Constants.GlintstoneStaffItemId + 25;
                    break;
                }
        }
        
        for (int i = 0; i < ParamsEditor.TotalStartingClasses; i++)
        {
            int charaInitId = ParamsEditor.VagabondCharaInitId + i;
            
            // clear all starting gear, spells, etc.
            randomizerServiceStartingClass.ClearLoadout(editor, charaInitId);

            // set starting stats
            randomizerServiceStartingClass.ApplyStatAllocation(editor, charaInitId, startingStats);
            editor.SetInitialRuneLevel(charaInitId, 1);

            // give initial weapons (club +0, staff +25, seal +25)
            editor.SetInitialEquipWepRight(charaInitId, 0, ClubItemId);
            editor.SetInitialEquipWepLeft(charaInitId, 0, GlintstoneStaffItemId);
            editor.SetInitialEquipWepLeft(charaInitId, 1, FingerSealItemId);

            // initial runes and flasks
            editor.SetInitialRunes(charaInitId, NumberOfStartingRunes);
            editor.SetInitialMaxHpFlasks(charaInitId, 12);
            editor.SetInitialMaxFpFlasks(charaInitId, 2);

            if (mode == DlcMode.Moonwalk)
            {
                // Give initial sorceries/incantations
                editor.SetInitialEquipSpell(charaInitId, 0, 4431); // adula's moonblade
            }
            else if (mode == DlcMode.Omenveil)
            {
                // Give initial tools
                editor.SetInitialEquipItem(charaInitId, 0, 3011); // regal omen bairn
                editor.SetInitialEquipItemAmount(charaInitId, 0, 1);
                
                editor.SetInitialEquipItem(charaInitId, 1, 2150); // mohg's shackle
                editor.SetInitialEquipItemAmount(charaInitId, 1, 1);
                
                editor.SetInitialEquipItem(charaInitId, 2, 260000); // dung eater puppet
                editor.SetInitialEquipItemAmount(charaInitId, 2, 1);

                // give incants
                editor.SetInitialEquipSpell(charaInitId, 0, 7500); // tail
                editor.SetInitialEquipSpell(charaInitId, 1, 7510); // horns
                editor.SetInitialEquipSpell(charaInitId, 2, 7520); // breath
            }
            else if (mode == DlcMode.Anamnesis)
            {
                editor.SetInitialMaxHpFlasks(charaInitId, 6);
                editor.SetInitialMaxFpFlasks(charaInitId, 1);

            }

        }
    }

    private void InitDlcShop(ParamsEditor editor, OptimizedReplacementRandomizer urr, DlcMode mode = DlcMode.Default)
    {
        using DebugTimer _ = new DebugTimer("InitDlcShop");

        string shopItemsFilePath = $"{Constants.Misc}/dlc/shop_items.csv";
        string shopArmorSetsFilePath;
        string shopWeaponsFilePath;

        switch (mode)
        {
            case DlcMode.Moonwalk:
                {
                    shopArmorSetsFilePath = $"{Constants.Misc}/dlc/moonwalk/shop_armor_sets.csv";
                    shopWeaponsFilePath = $"{Constants.Misc}/dlc/moonwalk/shop_weapons.csv";
                    break;
                }
            case DlcMode.Omenveil:
                {
                    shopItemsFilePath = $"{Constants.Misc}/dlc/omenveil/shop_items.csv";
                    shopArmorSetsFilePath = $"{Constants.Misc}/dlc/omenveil/shop_armor_sets.csv";
                    shopWeaponsFilePath = $"{Constants.Misc}/dlc/omenveil/shop_weapons.csv";
                    break;
                }
            case DlcMode.Anamnesis:
                {
                    shopItemsFilePath = $"{Constants.Misc}/dlc/anamnesis/shop_items.csv";
                    shopArmorSetsFilePath = $"{Constants.Misc}/dlc/anamnesis/shop_armor_sets.csv";
                    shopWeaponsFilePath = $"{Constants.Misc}/dlc/anamnesis/shop_weapons.csv";
                    break;
                }
            default:
                {
                    shopArmorSetsFilePath = $"{Constants.Misc}/dlc/default/shop_armor_sets.csv";
                    shopWeaponsFilePath = $"{Constants.Misc}/dlc/default/shop_weapons.csv";
                    break;
                }
        }

        List<ShopItemModel> shopItems = CsvReaderUtils.Read<ShopItemModel>(shopItemsFilePath);

        // Setup the Runes shop.
        int currentShopLineupId = 9100000;
        uint currentEventFlagID = 1056447000;
        uint eventFlagStepSize = 10;
        for (int i = 0; i < shopItems.Count; i++)
        {
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - {shopItems[i].Type}] {shopItems[i].Name}";
            int equipID = shopItems[i].ID;
            byte equipType = shopItems[i].EquipType;
            int sellPrice = shopItems[i].Cost;
            short sellQuantity = shopItems[i].SellQuantity;
            uint eventFlagForQuantity;
            if (shopItems[i].EventFlagID == null)
            {
                eventFlagForQuantity = currentEventFlagID;
                currentEventFlagID += eventFlagStepSize;
            }
            else
            {
                eventFlagForQuantity = (uint)shopItems[i].EventFlagID!;
            }
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipType);
            editor.SetShopLineupSellPrice(shopLineupId, sellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, sellQuantity);
        }

        // Setup the randomized armor set in the runes shop.
        List<ArmorSetModel> armorGroup = CsvReaderUtils.Read<ArmorSetModel>(shopArmorSetsFilePath);
        int baseSeed = urr.GetBaseSeed();
        SeedManager seedManager = new SeedManager(SeedManagerPrefix, baseSeed);
        Random rng = seedManager.GetRandomByKey("armor_sets.csv");
        ArmorSetModel armor = armorGroup[rng.Next(armorGroup.Count)];

        byte armorEquipType = 1;
        short armorSellQuantity = 1;
        int helmSellPrice = 3000;
        int torsoSellPrice = 4500;
        int gauntletsSellPrice = 3000;
        int greavesSellPrice = 3000;
        
        if (armor.HelmID != null)
        {
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Armor] {armor.Name} Helm";
            int equipID = (int)armor.HelmID;
            uint eventFlagForQuantity = currentEventFlagID;
            currentEventFlagID += eventFlagStepSize;
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, armorEquipType);
            editor.SetShopLineupSellPrice(shopLineupId, helmSellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, armorSellQuantity);
        }
        if (armor.TorsoID != null)
        {
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Armor] {armor.Name} Torso";
            int equipID = (int)armor.TorsoID;
            uint eventFlagForQuantity = currentEventFlagID;
            currentEventFlagID += eventFlagStepSize;
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, armorEquipType);
            editor.SetShopLineupSellPrice(shopLineupId, torsoSellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, armorSellQuantity);
        }
        if (armor.GauntletsID != null)
        {
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Armor] {armor.Name} Gauntlets";
            int equipID = (int)armor.GauntletsID;
            uint eventFlagForQuantity = currentEventFlagID;
            currentEventFlagID += eventFlagStepSize;
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, armorEquipType);
            editor.SetShopLineupSellPrice(shopLineupId, gauntletsSellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, armorSellQuantity);
        }
        if (armor.GreavesID != null)
        {
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Armor] {armor.Name} Greaves";
            int equipID = (int)armor.GreavesID;
            uint eventFlagForQuantity = currentEventFlagID;
            currentEventFlagID += eventFlagStepSize;
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, armorEquipType);
            editor.SetShopLineupSellPrice(shopLineupId, greavesSellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, armorSellQuantity);
        }
        
        // Setup the Starlight Shards shop.
        byte starlightShardCostType = 2;
        short starlightWeaponSellQuantity = 1;
        ushort starlightWeaponNumSold;
        int starlightWeaponCost = 5;
        int currentCustomWeaponId = 9600069;
        currentShopLineupId = 9200000;
        currentEventFlagID = 1056457000;

        int numberOfShopWeapons = mode == DlcMode.Anamnesis ? 4 : 3;

        int GraftedDragonItemId = 21060009;

        // Setup the randomized weapons in the Starlight Shards shop. It has 3 total.
        // The Starlight Shards shop may share weapons from the common pool (there can be duplicates if the csv has duplicates)
        List<GameItemModel> starlightWeapons = CsvReaderUtils.Read<GameItemModel>(shopWeaponsFilePath);
        OptimizedRandomizationGroup merchantMillicentWeapons = new(numberOfShopWeapons, starlightWeapons.Count);
        urr.AddGroup("merchantMillicentWeapons", merchantMillicentWeapons);
        int[] replacementIndexes = urr.RandomizeGroup("merchantMillicentWeapons");

        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            int shopLineupId = currentShopLineupId++;
            uint eventFlagForQuantity = currentEventFlagID;
            currentEventFlagID += eventFlagStepSize;

            GameItemModel weapon = starlightWeapons[replacementIndexes[i]];
            int replacementEquipID = weapon.ID;
            int equipID = weapon.ID;

            if (mode == DlcMode.Anamnesis)
            {
                anamnesisStarlightWeapons[i] = equipID;
            }

            // Set reinforce level differently depending on if the weapon is custom or not
            if (weapon.EquipType == 5)
            {
#if DEBUG
                Debug.WriteLine("Custom weapon detected in shop");
#endif
                equipID = currentCustomWeaponId;

                int baseEquipID = editor.GetEquipCustomWeaponBaseWeaponId(replacementEquipID);
                int gemID = editor.GetEquipCustomWeaponGemId(replacementEquipID);
                int materialId = editor.GetEquipWeaponMaterialSetId(baseEquipID);
                byte reinforceLevel = materialId == 2200 ? (byte)9 : (byte)24;

                // Create a new CustomWeapon with the appropriate reinforceLevel
                editor.CreateNewEquipCustomWeaponRow(currentCustomWeaponId, weapon.Name);
                editor.SetEquipCustomWeaponBaseWeaponId(currentCustomWeaponId, baseEquipID);
                editor.SetEquipCustomWeaponGemId(currentCustomWeaponId, gemID);
                editor.SetEquipCustomWeaponReinforceLevel(currentCustomWeaponId, reinforceLevel);

                currentCustomWeaponId += 2; // maintain odd IDs
            }
            else
            {
                // For standard weapons, the reinforceLevel is just added to the weaponID
                int materialId = editor.GetEquipWeaponMaterialSetId(equipID);
                equipID = materialId == 2200 ? equipID + 9 : equipID + 24;
            }

            //Dual-Wielding Grafted Dragons
            if (equipID == GraftedDragonItemId)
            {
                starlightWeaponNumSold = (ushort)2;
                //editor.SetEquipWeaponMaxAmmunition(21060000, 0);
                
            }
            else
            {
                starlightWeaponNumSold = (ushort)1;
            }
            
            string name = $"[Merchant Millicent - Starlight Shop - Weapon] {weapon.Name}";
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, weapon.EquipType);
            editor.SetShopLineupCostType(shopLineupId, starlightShardCostType);
            editor.SetShopLineupSellPrice(shopLineupId, starlightWeaponCost);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupNumSold(shopLineupId, starlightWeaponNumSold);
            editor.SetShopLineupSellQuantity(shopLineupId, starlightWeaponSellQuantity);
            editor.SetShopLineupMenuTextId(shopLineupId, StarlightShopMenuTextId);
        }
        
        List<ShopItemModel> physickTears = new();
        List<ShopItemModel> talismans = new();
        for (int i = 0; i < shopItems.Count; i++)
        {
            if (shopItems[i].Type == "Physick Tear")
            {
                physickTears.Add(shopItems[i]);
            } else if (shopItems[i].Type == "Talisman")
            {
                talismans.Add(shopItems[i]);
            }
        }
        
        currentShopLineupId = 9201000;
        foreach (ShopItemModel item in physickTears)
        {
            string itemType = item.Type;
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Starlight Shop - {item.Type}] {item.Name}";
            int equipID = item.ID;
            byte equipType = item.EquipType;
            short sellQuantity = item.SellQuantity;
            uint eventFlagForQuantity;
            if (item.EventFlagID == null)
            {
                eventFlagForQuantity = currentEventFlagID;
                currentEventFlagID += eventFlagStepSize;
            }
            else
            {
                eventFlagForQuantity = (uint)item.EventFlagID!;
            }
            int sellPrice = 1;
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipType);
            editor.SetShopLineupCostType(shopLineupId, starlightShardCostType);
            editor.SetShopLineupSellPrice(shopLineupId, sellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, sellQuantity);
            editor.SetShopLineupMenuTextId(shopLineupId, StarlightShopMenuTextId);
        }

        currentShopLineupId = 9202000;
        foreach (ShopItemModel item in talismans)
        {
            string itemType = item.Type;
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Starlight Shop - {item.Type}] {item.Name}";
            int equipID = item.ID;
            byte equipType = item.EquipType;
            short sellQuantity = item.SellQuantity;
            uint eventFlagForQuantity;
            if (item.EventFlagID == null)
            {
                eventFlagForQuantity = currentEventFlagID;
                currentEventFlagID += eventFlagStepSize;
            }
            else
            {
                eventFlagForQuantity = (uint)item.EventFlagID!;
            }
            int sellPrice = 1;
            if (item.Cost > 40000)
            {
                sellPrice = 3;
            }
            else if (item.Cost > 20000)
            {
                sellPrice = 2;
            }
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipType);
            editor.SetShopLineupCostType(shopLineupId, starlightShardCostType);
            editor.SetShopLineupSellPrice(shopLineupId, sellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, sellQuantity);
            editor.SetShopLineupMenuTextId(shopLineupId, StarlightShopMenuTextId);
        }
    }

    private void InitAnamnesisRemembrances(ParamsEditor editor, OptimizedReplacementRandomizer urr)
    {
        int[] shopLineupIDTargets = new int[]
        {
            101898, // Enraged Divine Beast
            101899, // AoW: Divine Beast Frost Stomp
            101930, // Rellana's Twin Blades
            101931, // Rellana's Twin Moons
            101932, // Sword Lance
            101933, // Blades of Stone
            101934, // Putrescence Cleaver
            101935, // Vortex of Putrescence
            101936, // Poleblade of the Bud
            101937, // Rotten Butterflies
            101938, // Greatsword of Damnation
            101939, // Midra's Flame of Frenzy
            101940, // Shadow Sunflower Blossom
            101941, // Land of Shadow
            101942, // Spear of the Impaler
            101943, // Messmer's Orb
            101944, // Staff of the Great Beyond
            101945, // Gazing Finger
            101946, // Greatsword of Radahn (Lord)
            101947, // Greatsword of Radahn (Light)
            101948, // Light of Miquella
        };
        List<GameItemModel> remembranceWeaponReplacements = CsvReaderUtils.Read<GameItemModel>($"{Constants.Misc}/dlc/anamnesis/remembrances/replacements.csv");

#if DEBUG
        Debug.WriteLine($"remembrance weapons length: {remembranceWeaponReplacements.Count()}");
#endif
        remembranceWeaponReplacements.RemoveAll(gameItemModel => anamnesisStarlightWeapons.Contains(gameItemModel.ID));
#if DEBUG
        Debug.WriteLine($"remembrance weapons length: {remembranceWeaponReplacements.Count()}");
#endif

        OptimizedRandomizationGroup remembrancesGroup = new(shopLineupIDTargets.Count(), remembranceWeaponReplacements.Count());
        urr.AddGroup("anamnesisRemembrancesGroup", remembrancesGroup);
        int[] replacementIndexes = urr.RandomizeGroup("anamnesisRemembrancesGroup");

        for (int i = 0; i < shopLineupIDTargets.Count(); i++)
        {
            editor.SetShopLineupEquipId(shopLineupIDTargets[i], remembranceWeaponReplacements[replacementIndexes[i]].ID);
            editor.SetShopLineupEquipType(shopLineupIDTargets[i], remembranceWeaponReplacements[replacementIndexes[i]].EquipType);
        }
    }

    public void DisableUpgradingClub(ParamsEditor editor)
    {
        int ClubItemId = 11010000;

        editor.SetEquipWeaponIsCustom(ClubItemId, 0);
        editor.SetEquipWeaponMaterialSetId(ClubItemId, 0);
        editor.SetEquipWeaponReinforceTypeId(ClubItemId, 3000);
        editor.SetEquipWeaponReinforceShopCategory(ClubItemId, 0);
    }

    public void EquipMillicentsArmor(ParamsEditor editor, DlcMode mode = DlcMode.Default)
    {
        int merchantMillicentCharaInitId = 23489;
        int helmId;
        int torsoId;
        int armId;
        int legId;

        switch (mode)
        {
            case DlcMode.Moonwalk:
                {
                    // Snow Witch Set
                    helmId = 1010000;
                    torsoId = 1010100;
                    armId = -1;
                    legId = 1010300;
                    break;
                }
            case DlcMode.Omenveil:
                {
                    helmId = -1;
                    torsoId = 1050100;
                    armId = -1;
                    legId = -1;
                    break;
                }
            case DlcMode.Anamnesis:
                {
                    helmId = 770000;
                    torsoId = 771100;
                    armId = 770200;
                    legId = 770300;
                    break;
                }
            default:
                {
                    // Millicent's Set (including custom missing arm)
                    helmId = -1;
                    torsoId = 1971100;
                    armId = 1971200;
                    legId = 1950300;
                    break;
                }
        }

        editor.SetInitialEquipHelm(merchantMillicentCharaInitId, helmId);
        editor.SetInitialEquipTorso(merchantMillicentCharaInitId, torsoId);
        editor.SetInitialEquipArm(merchantMillicentCharaInitId, armId);
        editor.SetInitialEquipLeg(merchantMillicentCharaInitId, legId);
    }

    private void ModeCustomization(DlcMode mode)
    {
        //Anamnesis-only Title Screen
        string menuPath = Path.Combine(Constants.MenuBndOutDlc, "menu");
        string menuAnamnesisPath = Path.Combine(Constants.MenuBndOutDlc, "menu_anamnesis");
        UpdateFolder(
            targetPath: menuPath,
            sourcePath: mode == DlcMode.Anamnesis ? menuAnamnesisPath : null
        );

        // Events (default vs Anamnesis)
        string eventPath = Path.Combine(Constants.MenuBndOutDlc, "event");
        string eventDefaultPath = Path.Combine(Constants.MenuBndOutDlc, "event_default");
        string eventAnamnesisPath = Path.Combine(Constants.MenuBndOutDlc, "event_anamnesis");

        UpdateFolder(
            targetPath: eventPath,
            sourcePath: mode == DlcMode.Anamnesis
                ? eventAnamnesisPath
                : eventDefaultPath
        );
    }

    private static void UpdateFolder(string targetPath, string? sourcePath)
    {
        if (sourcePath != null &&
            Path.GetFullPath(sourcePath) == Path.GetFullPath(targetPath))
        {
            return;
        }


        Directory.CreateDirectory(targetPath);

        // clear target
        foreach (var file in Directory.GetFiles(targetPath))
        {
            File.SetAttributes(file, FileAttributes.Normal);
            File.Delete(file);
        }

        foreach (var dir in Directory.GetDirectories(targetPath))
        {
            Directory.Delete(dir, true);
        }

        // populate if source exists
        if (sourcePath == null || !Directory.Exists(sourcePath))
            return;

        foreach (var dir in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
        {
            Directory.CreateDirectory(dir.Replace(sourcePath, targetPath));
        }

        foreach (var file in Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories))
        {
            string dest = file.Replace(sourcePath, targetPath);
            Directory.CreateDirectory(Path.GetDirectoryName(dest)!);
            File.Copy(file, dest, true);
        }
    }



}
