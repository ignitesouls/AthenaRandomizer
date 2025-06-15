// SPDX-License-Identifier: GPL-3.0-only
using Athena.Config;
using Athena.Utilities;
using Athena.Models;
using EldenRingParamsEditor;
using System.Diagnostics;
using UniversalReplacementRandomizer;

namespace Athena.Services;

public class DlcRandomizerService
{
    private const string SeedManagerPrefix = "dlc";
    private const int StarlightShopMenuTextId = 508000;

    public void RandomizeDlc(int? baseSeed,
                             Action<int?>? updateBaseSeedCallback,
                             Action<int?>? updateRandomizedSeedCallback)
    {
        using DebugTimer _ = new DebugTimer("RandomizeDlc");

        var editor = ParamsEditor.ReadFromRegulationPath(Constants.RegulationInDlc);
        
        //MetadataUtils.GenerateWeaponsMappings(editor);

        var urr = new OptimizedReplacementRandomizer(SeedManagerPrefix, baseSeed);
        if (baseSeed == null)
        {
            updateBaseSeedCallback?.Invoke(urr.GetBaseSeed());
        }
        
        InitStartingClasses(editor);
        InitDlcShop(editor, urr);
        ReplacementUtils.Randomize<GameItemModel>(editor, urr, Constants.RandomizationGroupsDlc);

        editor.WriteToRegulationPath(Constants.RegulationOutDlc);

        updateRandomizedSeedCallback?.Invoke(urr.GetBaseSeed());
    }
    
    private void InitStartingClasses(ParamsEditor editor)
    {
        using DebugTimer _ = new DebugTimer("InitStartingClasses");

        int NumberOfStartingRunes = 100000;

        int ClubItemId = 11010000;
        int GlintstoneStaffItemId = 33000025;
        int FingerSealItemId = 34000025;
        for (int i = 0; i < ParamsEditor.TotalStartingClasses; i++)
        {
            int charaInitId = ParamsEditor.VagabondCharaInitId + i;

            // reset all stats
            editor.SetInitialRuneLevel(charaInitId, 1);
            editor.SetInitialVigor(charaInitId, 50);
            editor.SetInitialMind(charaInitId, 10);
            editor.SetInitialEndurance(charaInitId, 10);
            editor.SetInitialStrength(charaInitId, 10);
            editor.SetInitialDexterity(charaInitId, 10);
            editor.SetInitialIntelligence(charaInitId, 10);
            editor.SetInitialFaith(charaInitId, 10);
            editor.SetInitialArcane(charaInitId, 10);

            // initial runes and flasks
            editor.SetInitialRunes(charaInitId, NumberOfStartingRunes);
            editor.SetInitialMaxHpFlasks(charaInitId, 12);
            editor.SetInitialMaxFpFlasks(charaInitId, 2);

            // clear all initial equipment
            for (int j = 0; j < 2; j++)
            {
                editor.SetInitialEquipWepRight(charaInitId, j, -1);
                editor.SetInitialEquipWepLeft(charaInitId, j, -1);
            }
            for (int j = 0; j < 4; j++)
            {
                editor.SetInitialEquipAmmunition(charaInitId, j, -1, 0);
            }
            for (int j = 0; j < 7; j++)
            {
                editor.SetInitialEquipSpell(charaInitId, j, -1);
            }
            editor.SetInitialEquipHelm(charaInitId, -1);
            editor.SetInitialEquipTorso(charaInitId, -1);
            editor.SetInitialEquipArm(charaInitId, -1);
            editor.SetInitialEquipLeg(charaInitId, -1);

            // clear all items
            for (int j = 0; j < 10; j++)
            {
                editor.SetInitialEquipItem(charaInitId, j, -1);
                editor.SetInitialEquipItemAmount(charaInitId, j, 0);
            }

            // give initial weapons (club +0, staff +25, seal +25)
            editor.SetInitialEquipWepRight(charaInitId, 0, ClubItemId);
            editor.SetInitialEquipWepLeft(charaInitId, 0, GlintstoneStaffItemId);
            editor.SetInitialEquipWepLeft(charaInitId, 1, FingerSealItemId);
        }
    }

    private void InitDlcShop(ParamsEditor editor, OptimizedReplacementRandomizer urr)
    {
        using DebugTimer _ = new DebugTimer("InitDlcShop");

        List<ShopItemModel> shopItems = CsvReaderUtils.Read<ShopItemModel>($"{Constants.Misc}/dlc/MerchantMillicentShopItems.csv");

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
        List<ArmorSetModel> armorGroup = CsvReaderUtils.Read<ArmorSetModel>($"{Constants.Misc}/dlc/armor_sets.csv");
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
        short starlightWeaponSellPrice = 1;
        int starlightWeaponCost = 5;
        int currentCustomWeaponId = 9600069;
        currentShopLineupId = 9200000;
        currentEventFlagID = 1056457000;

        // Setup the randomized weapons in the Starlight Shards shop. It has 3 total.
        // The Starlight Shards shop shares weapons from the common pool (there can be duplicates)
        List<GameItemModel> common = CsvReaderUtils.Read<GameItemModel>($"{Constants.RandomizationGroupsDlc}/common.csv");
        OptimizedRandomizationGroup starlightShop = new(3, common.Count);
        urr.AddGroup("starlightShop", starlightShop);
        int[] replacementIndexes = urr.RandomizeGroup("starlightShop");

        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            int shopLineupId = currentShopLineupId++;
            uint eventFlagForQuantity = currentEventFlagID;
            currentEventFlagID += eventFlagStepSize;

            GameItemModel weapon = common[replacementIndexes[i]];
            int replacementEquipID = weapon.ID;
            int equipID = weapon.ID;

            // Set reinforce level differently depending on if the weapon is custom or not
            if (weapon.EquipType == 5)
            {
                Debug.WriteLine("Custom weapon detected in shop");
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

                currentCustomWeaponId += 2; // increment by 2 so it never ends in 0
            }
            else
            {
                // For standard weapons, the reinforceLevel is just added to the weaponID
                int materialId = editor.GetEquipWeaponMaterialSetId(equipID);
                equipID = materialId == 2200 ? equipID + 9 : equipID + 24;
            }
            
            string name = $"[Merchant Millicent - Starlight Shop - Weapon] {weapon.Name}";
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, weapon.EquipType);
            editor.SetShopLineupCostType(shopLineupId, starlightShardCostType);
            editor.SetShopLineupSellPrice(shopLineupId, starlightWeaponCost);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, starlightWeaponSellPrice);
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
}
