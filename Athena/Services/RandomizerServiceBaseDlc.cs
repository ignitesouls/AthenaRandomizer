// SPDX-License-Identifier: GPL-3.0-only
using Athena.Config;
using Athena.Models;
using Athena.Utilities;
using DotNext;
using EldenRingParamsEditor;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using UniversalReplacementRandomizer;

namespace Athena.Services;

//Set New Enum For Veilbreak Randomized Starting Graces `VCC`
public enum BaseDlcMode
{
    Default,
    VCC
}

public class RandomizerServiceBaseDlc
{
    private string SeedManagerPrefix;
    RandomizerServiceStartingClass randomizerServiceStartingClass = new();

    public RandomizerServiceBaseDlc(string appVersion)
    {
        SeedManagerPrefix = "basedlc" + appVersion;
    }


    //
    public void RandomizeBaseDlc(int? baseSeed,
                                 BaseDlcMode mode,
                                 Action<int?>? updateBaseSeedCallback,
                                 Action<int?>? updateRandomizedSeedCallback,
                                 Action<BaseDlcMode?>? updatedRandomizedModeBaseDlcCallback)
    {
        using DebugTimer _ = new DebugTimer("RandomizeBaseDlc");

        var editor = ParamsEditor.ReadFromRegulationPath(Constants.RegulationInBaseDlc);
        var menuBndEditor = MenuBndEditorService.ReadFromMenuBndFilePath(Constants.MenuBndInBaseDlc);

        string seedManagerPrefix;


        switch (mode)
        {
            case BaseDlcMode.VCC:
                {
                    seedManagerPrefix = SeedManagerPrefix + "_vcc";
                    break;
                }
            default:
                {
                    seedManagerPrefix = SeedManagerPrefix;
                    break;
                }
        }


        var urr = new OptimizedReplacementRandomizer(seedManagerPrefix, baseSeed);
        if (baseSeed == null)
        {
            updateBaseSeedCallback?.Invoke(urr.GetBaseSeed());
        }

        //When the Mode is Set to VCC Randomize the Graces within the Pool
        if (mode == BaseDlcMode.VCC)
        {
            RandomizeGrace(editor, urr);
        }

        // Generate stats and starting equipment
        RandomizeStartingClassesBaseDlc(editor, menuBndEditor, urr);

        // Randomize weapons, spells, and incantations
        RandomizeAllGroupsBaseDlc(editor, urr);

        // Remove roundtable fist check, change Seluvis's Potion to Magic Scorpion Charm, Sentry Torch at Altus merchant
        OverrideDropsBaseDlc(editor);

        // Prevent serpent hunter from being upgraded
        DisableSerpentHunter(editor);

        // Initialize the Talisman Shop
        InitBaseDlcShop(editor);

        ModeCustomization(mode);

        editor.WriteToRegulationPath(Constants.RegulationOutBaseDlc);
        menuBndEditor.WriteToMenuBndFilePath(Constants.MenuBndOutBaseDlc);

        updateRandomizedSeedCallback?.Invoke(urr.GetBaseSeed());
        updatedRandomizedModeBaseDlcCallback?.Invoke(mode); 
    }

    private void RandomizeStartingClassesBaseDlc(ParamsEditor editor, MenuBndEditorService menuBndEditor, OptimizedReplacementRandomizer urr)
    {
        using DebugTimer _ = new DebugTimer("RandomizeStartingClassesBaseDlc");

        var classStatAllocations = randomizerServiceStartingClass.GenerateAllClassStats(urr);
        var armorSetAllocations = randomizerServiceStartingClass.GenerateArmorSets(urr, $"{Constants.Misc}/basedlc/starting_classes");
        var weaponSetAllocations = randomizerServiceStartingClass.GenerateWeaponSets(urr, $"{Constants.Misc}/basedlc/starting_classes");

        for (int i = 0; i < ParamsEditor.TotalStartingClasses; i++)
        {
            int charaInitId = ParamsEditor.VagabondCharaInitId + i;

            // remove all starting gear, spells, etc.
            randomizerServiceStartingClass.ClearLoadout(editor, charaInitId);

            // allocate randomly generated stats
            var statAllocation = classStatAllocations[i];
            randomizerServiceStartingClass.ApplyStatAllocation(editor, charaInitId, statAllocation);
            editor.SetInitialRuneLevel(charaInitId, 9);

            // allocate randomly generated armor
            var armorAllocation = armorSetAllocations[i];
            randomizerServiceStartingClass.ApplyArmorSet(editor, charaInitId, armorAllocation);

            // allocate randomly generated weapons
            var weaponAllocation = weaponSetAllocations[i];
            randomizerServiceStartingClass.ApplyWeaponSet(editor, charaInitId, weaponAllocation);

            // get class description with all weapons/stat deficits (if any)
            string classDescription = randomizerServiceStartingClass.GenerateClassDescription(editor, armorAllocation, weaponAllocation, statAllocation);

            // guaranteed sorcery / staff
            if (i == 4) // astrologer
            {
                List<GameItemModel> sorceries = CsvReaderUtils.Read<GameItemModel>($"{Constants.Misc}/basedlc/starting_classes/sorceries.csv");
                Random rng = urr.GetSeedManager().GetRandomByKey("starting_sorceries");
                GameItemModel sorcery = sorceries[rng.Next(sorceries.Count)];
                editor.SetInitialEquipSpell(charaInitId, 0, sorcery.ID);
                editor.SetInitialEquipWepLeft(charaInitId, 1, Constants.GlintstoneStaffItemId);
                classDescription += $", Glintstone Staff, {sorcery.Name}";
            }

            // guaranteed incantation / seal
            if (i == 5) // prophet
            {
                List<GameItemModel> incantations = CsvReaderUtils.Read<GameItemModel>($"{Constants.Misc}/basedlc/starting_classes/incantations.csv");
                Random rng = urr.GetSeedManager().GetRandomByKey("starting_incantations");
                GameItemModel incantation = incantations[rng.Next(incantations.Count)];
                editor.SetInitialEquipSpell(charaInitId, 0, incantation.ID);
                editor.SetInitialEquipWepLeft(charaInitId, 1, Constants.FingerSealItemId);
                classDescription += $", Finger Seal, {incantation.Name}";
            }

            // give 10k starting runes
            editor.SetInitialRunes(charaInitId, 10_000);

            menuBndEditor.SetClassDescription(i, classDescription);
        }
    }

    public void RandomizeAllGroupsBaseDlc(ParamsEditor editor, OptimizedReplacementRandomizer urr)
    {
        var weaponIdsToItemLotMap = editor.GetWeaponIdsToItemLotMap();
        var weaponIdsToItemLotEnemy = editor.GetWeaponIdsToItemLotEnemy();
        var weaponIdsToShopLineup = editor.GetWeaponIdsToShopLineup();

        var goodsIdsToItemLotMap = editor.GetGoodsIdsToItemLotMap();
        var goodsIdsToItemLotEnemy = editor.GetGoodsIdsToItemLotEnemy();
        var goodsIdsToShopLineup = editor.GetGoodsIdsToShopLineup();

        // incantations, dragon communion incantations, sorceries
        ReplacementUtils.Randomize<GameItemModel>(editor,
                                                  urr,
                                                  $"{Constants.RandomizationGroupsBaseDlc}/spells",
                                                  goodsIdsToItemLotMap,
                                                  goodsIdsToItemLotEnemy,
                                                  goodsIdsToShopLineup);

        // chance weapons (randomized within classes)
        ReplacementUtils.RandomizeItemLotEnemy<WeaponModel>(editor,
                                                            urr,
                                                            $"{Constants.RandomizationGroupsBaseDlc}/chance_weapons",
                                                            weaponIdsToItemLotEnemy);

        // guaranteed and map weapons (randomized within classes)
        ReplacementUtils.Randomize<GameItemModel>(editor,
                                                  urr,
                                                  $"{Constants.RandomizationGroupsBaseDlc}/map_guaranteed_weapons",
                                                  weaponIdsToItemLotMap,
                                                  weaponIdsToItemLotEnemy,
                                                  weaponIdsToShopLineup);

        // remembrance weapons
        ReplacementUtils.RandomizeAndReplaceShopLineupFile<WeaponModel>(editor,
                                                                       urr,
                                                                       $"{Constants.RandomizationGroupsBaseDlc}/remembrances/weapons.csv",
                                                                       weaponIdsToShopLineup);

        // remembrance sorceries
        ReplacementUtils.RandomizeAndReplaceShopLineupFile<WeaponModel>(editor,
                                                                       urr,
                                                                       $"{Constants.RandomizationGroupsBaseDlc}/remembrances/sorceries.csv",
                                                                       goodsIdsToShopLineup);

        // remembrance incantations
        ReplacementUtils.RandomizeAndReplaceShopLineupFile<WeaponModel>(editor,
                                                                       urr,
                                                                       $"{Constants.RandomizationGroupsBaseDlc}/remembrances/incantations.csv",
                                                                       goodsIdsToShopLineup);

        // shop weapons
        ReplacementUtils.RandomizeAndReplaceShopLineupDir<WeaponModel>(editor,
                                                                       urr,
                                                                       $"{Constants.RandomizationGroupsBaseDlc}/shop_weapons",
                                                                       weaponIdsToShopLineup);

        // override perfume bottles
        ReplacementUtils.Randomize<GameItemModel>(editor,
                                                  urr,
                                                  $"{Constants.RandomizationGroupsBaseDlc}/perfume_bottles",
                                                  weaponIdsToItemLotMap,
                                                  weaponIdsToItemLotEnemy,
                                                  weaponIdsToShopLineup);
    }

    public void OverrideDropsBaseDlc(ParamsEditor editor)
    {
        // Remove fist check in roundtable
        int cipherPataId = 11100000;
        editor.SetItemLotMapLotItemId(cipherPataId, 0, 0);
        editor.SetItemLotMapCategory(cipherPataId, 0, 0);
        editor.SetItemLotMapItemNum(cipherPataId, 0, 0);
        
        // Change Seluvis's Potion to Magic Scorpion Charm
        //int seluvisPotionId = 101400;
        //int magicScorpionCharmId = 2000;
        //byte talismanCategory = 4;
        //editor.SetItemLotMapLotItemId(seluvisPotionId, 0, magicScorpionCharmId);
        //editor.SetItemLotMapCategory(seluvisPotionId, 0, talismanCategory);

        // Replace an item in Seluvis's shop with Magic Scorpion Charm
        int pidiaOldFangId = 100329;
        int magicScorpionCharmId = 2000;
        byte talismanEquipType = 2;
        uint magicScorpionAcquisitionFlag = 400141;
        short sellQuantity = 1;
        int sellPrice = 5000;
        editor.SetShopLineupEquipId(pidiaOldFangId, magicScorpionCharmId);
        editor.SetShopLineupEquipType(pidiaOldFangId, talismanEquipType);
        editor.SetShopLineupEventFlagForStock(pidiaOldFangId, magicScorpionAcquisitionFlag);
        editor.SetShopLineupSellQuantity(pidiaOldFangId, sellQuantity);
        editor.SetShopLineupSellPrice(pidiaOldFangId, sellPrice);

        // Remove Somber Ancient Dragon Smithing Stone from Mohgwyn
        //int mohgwynSomberStone = 12050900;
        //editor.SetItemLotMapLotItemId(mohgwynSomberStone, 0, 0);
        //editor.SetItemLotMapCategory(mohgwynSomberStone, 0, 0);
    }

    private void InitBaseDlcShop(ParamsEditor editor)
    {
        using DebugTimer _ = new DebugTimer("InitBaseDlcShop");

        List<ShopItemModel> shopItems = CsvReaderUtils.Read<ShopItemModel>($"{Constants.Misc}/basedlc/shop_talismans.csv");

        // Setup the Runes shop.
        int currentShopLineupId = 9300000;
        uint currentEventFlagID = 1056448000;
        uint eventFlagStepSize = 10;
        for (int i = 0; i < shopItems.Count; i++)
        {
            int shopLineupId = currentShopLineupId++;
            string name = $"[Bernie Bingo - {shopItems[i].Type}] {shopItems[i].Name}";
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
    }

    public void DisableSerpentHunter(ParamsEditor editor)
    {
        int serpentHunterId = 17030000;

        editor.SetEquipWeaponIsCustom(serpentHunterId, 0);
        editor.SetEquipWeaponMaterialSetId(serpentHunterId, 0);
        editor.SetEquipWeaponReinforceTypeId(serpentHunterId, 3000);
        editor.SetEquipWeaponReinforceShopCategory(serpentHunterId, 0);
    }

    private void ModeCustomization(BaseDlcMode mode)
    {
        // Events (default vs VCC)
        string eventPath = Path.Combine(Constants.MenuBndOutBaseDlcVCC, "event");
        string eventDefaultPath = Path.Combine(Constants.MenuBndOutBaseDlcVCC, "event_default");
        string eventVCCPath = Path.Combine(Constants.MenuBndOutBaseDlcVCC, "event_vcc");

        UpdateFolder(
            targetPath: eventPath,
            sourcePath: mode == BaseDlcMode.VCC
                ? eventVCCPath
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

    public void RandomizeGrace(ParamsEditor editor, OptimizedReplacementRandomizer urr)
    {
        // Limgrave, Pick 2 out of a North+South or East+West
        {
            var rng = urr.GetSeedManager().GetRandomByKey("grace_Limgrave");

            bool useNorthSouth = rng.Next(2) == 0;

            int[] aPool = useNorthSouth ? GracePools["Limgrave_North"] : GracePools["Limgrave_East"];
            int[] bPool = useNorthSouth ? GracePools["Limgrave_South"] : GracePools["Limgrave_West"];

            int first = aPool[rng.Next(aPool.Length)];

            //Second From the paired pool, guaranteed different (handle overlapping IDS)
            int second;
            int guard = 0;
            do
            {
                second = bPool[rng.Next(bPool.Length)];
                guard++;
            } while (second == first && guard < 100);

            editor.SetGraceEventFlagId(first);
            editor.SetGraceEventFlagId(second);
        }

        //Liurnia Pick 2 out of a North+South or East+West
        {
            var rng = urr.GetSeedManager().GetRandomByKey("grace_Liurnia");

            bool useNorthSouth = rng.Next(2) == 0;

            int[] aPool = useNorthSouth ? GracePools["Liurnia_North"] : GracePools["Liurnia_East"];
            int[] bPool = useNorthSouth ? GracePools["Liurnia_South"] : GracePools["Liurnia_West"];

            int first = aPool[rng.Next(aPool.Length)];

            int second;
            int guard = 0;
            do
            {
                second = bPool[rng.Next(bPool.Length)];
                guard++;
            } while (second == first && guard < 100);

            editor.SetGraceEventFlagId(first);
            editor.SetGraceEventFlagId(second);
        }

        //ALL OTHER POOLS: pick 1 each 
        foreach (var (poolName, pool) in GracePools)
        {
            // skip the sub-pools that were already handled as pairs above
            if (poolName.StartsWith("Limgrave_")) continue;
            if (poolName.StartsWith("Liurnia_")) continue;

            Random rng = urr.GetSeedManager().GetRandomByKey($"grace_{poolName}");
            int selectedGrace = pool[rng.Next(pool.Length)];
            editor.SetGraceEventFlagId(selectedGrace);
        }
    }

    private static readonly Dictionary<string, int[]> GracePools = new()
    {
        ["Limgrave_North"] = new[]
        {
            61413800, // Stormhill Shack
            61423800, // Warmaster Shack
            61433900, // Saintsbridge
            61463800, // Third Church of Marika
            61423700, // Gatefront
            61433700, // Agheel Lake North
            61443900, // Summoning Village Outskirts
        },
            ["Limgrave_South"] = new[]
        {
            61423601, // First Step
            61433500, // Seaside Ruins
            61443500, // Agheel Lake South
            180001,   // Stranded Graveyard
        },
            ["Limgrave_East"] = new[]
        {
            61433900, // Saintsbridge
            61463800, // Third Church of Marika
            61443800,  // Artist Shack
            61443500, // Agheel Lake South
            61433800  // Murkwater Coast
        },
            ["Limgrave_West"] = new[]
        {
            61413800, // Stormhill Shack
            61423800, // Warmaster Shack
            61423600, // Church of Elleh
            61423601, // First Step
            180001,   // Stranded Graveyard
            61433500, // Seaside Ruins
        },

        // LIURNIA 
        ["Liurnia_North"] = new[]
        {
            62364901, // The Ravine
            62384800, // Frenzied Flame Village Outskirts
            62354700, // East Gate Bridge Trestle
            62344701, // Sorceror's Island
            62364500, // Gate Town North
            62334600, // Foot of the 4 Belfries
            62344900, // Road to the Manor
            62364800, // East Raya Lucaria Gate
        },
            ["Liurnia_South"] = new[]
        {
            62354500, // South Raya Lucaria Gate
            62374400, // Academy Gate Town
            62364301, // Fallen Ruins of the Lake
            62374200, // Scenic Island
            62394200, // Liurnia Highway North
            62394100, // Liurnia Highway South
            62384100, // Laskay Ruins
            62384000, // Liurnia Lake Shore
        },
            ["Liurnia_East"] = new[]
        {
            62384300, // Gate Town Bridge
            62384100, // Laskay Ruins
            62374200, // Scenic Island
            62374400, // Academy Gate Town
            62394200, // Liurnia Highway North
            62384000, // Liurnia Lake Shore
            62384800, // Frenzied Flame Village Outskirts
            62384501, // Eastern Liurnia Lake Shore
        },
        ["Liurnia_West"] = new[]
        {
            62344400, // Temple Quarter
            62334600, // Foot of the 4 Belfries
            62344900, // Road to the Manor
            62344701, // Sorceror's Island
            62354700, // East Gate Bridge Trestle
            62364301, // Fallen Ruins of the Lake
            62344600, // Crystallian Woods
            62384500, // Artist Shack
        },
        // WEEPING 
        ["Weeping1"] = new[]
        {
            61413200, // Isolated Merchant Shack
            61443301, // South of the Lookout Tower
            61433400, // Church of Pilgrimage
            61443302, // Ailing Village Outskirts
            61443400, // Bridge of Sacrifice
            61443300, // Castle Morne Rampart
            61413300, // Fourth Church of Marika
            61423300, // Tombsward
        },
        // CAELID
            ["Caelid1"] = new[]
        {
            64493801, // Inner Aeonia
            64493902, // Sellia Understair
            64493900, // Sellia Backstreets
            64483800, // Aeonia Swamp Shore
            64474000, // Caelem Ruins
            64473900, // Fort Gael North
            64493700, // Southern Aeonia Swamp Bank
            64483801, // Astray from Caelid Highway North
            64483900, // Smoldering Wall
            64524100, // Lenna's Rise
            64484001, // Dragonbarrow West
        },
    };
}