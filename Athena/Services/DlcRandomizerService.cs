// SPDX-License-Identifier: GPL-3.0-only
using Athena.Config;
using Athena.Utilities;
using DotNext.Collections.Generic;
using EldenRingParamsEditor;
using System.Diagnostics;
using UniversalReplacementRandomizer;

namespace Athena.Services;

public class DlcRandomizerService
{
    public void RandomizeDlc(int? baseSeed, Action<int?> updateSeedCallback)
    {
        var editor = ParamsEditor.ReadFromRegulationPath(Constants.RegulationInDlc);

        //List<Weapon> weapons = CsvReaderUtils.Read<Weapon>($"{Constants.GameData}/AllWeapons.csv");
        //List<int> weaponIds = new();
        //foreach (Weapon weapon in weapons)
        //{
        //    weaponIds.Add(weapon.WeaponID);
        //}
        //editor.GenerateMappingWeaponIdsToItemLot(weaponIds);

        //List<CustomWeapon> customWeapons = CsvReaderUtils.Read<CustomWeapon>($"{Constants.GameData}/AllCustomWeapons.csv");
        //List<int> customWeaponIds = new();
        //foreach (CustomWeapon customWeapon in customWeapons)
        //{
        //    customWeaponIds.Add(customWeapon.WeaponID);
        //}
        //editor.GenerateMappingWeaponIdsToItemLot(weaponIds, customWeapons: true);

        //List<int> allWeaponIds = weaponIds.Concat(customWeaponIds).ToList();
        //editor.GenerateMappingWeaponIdsToItemLot(allWeaponIds);

        //editor.GenerateMappingWeaponIdsToShopLineup(allWeaponIds);

        var urr = new ReplacementRandomizer(baseSeed);
        if (baseSeed == null)
        {
            updateSeedCallback(urr.GetBaseSeed());
        }

        InitStartingClasses(editor);
        InitDlcShop(editor, urr);
        RandomizeGroups(editor, urr);

        editor.WriteToRegulationPath(Constants.RegulationOutDlc);
        
        Debug.WriteLine("DONE");
    }

    private void InitStartingClasses(ParamsEditor editor)
    {
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

            // give starlight shards
            editor.SetInitialEquipItem(charaInitId, 9, 1290);
            editor.SetInitialEquipItemAmount(charaInitId, 9, 10);
        }
    }

    private void InitDlcShop(ParamsEditor editor, ReplacementRandomizer urr)
    {
        List<ShopItem> shopItems = CsvReaderUtils.Read<ShopItem>($"{Constants.Misc}/DlcMerchantMillicentShopItems.csv");

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
        SeedManager seedManager = urr.GetSeedManager();
        Random rng = seedManager.GetRandomByKey("millicentArmor");

        // The armor sets are rows in a CSV. Choose one by using the RNG to select a random index
        List<ArmorSet> armorGroup = CsvReaderUtils.Read<ArmorSet>($"{Constants.RandomizationGroupsDlc}/armor_sets.csv");
        int chosenSet = rng.Next(armorGroup.Count);
        ArmorSet armor = armorGroup[chosenSet];

        // Set some common variable(s) here
        byte equipTypeProtector = 1;
        short armorSellQuantity = 1;
        int helmSellPrice = 3000;
        int torsoSellPrice = 4500;
        int gauntletsSellPrice = 3000;
        int greavesSellPrice = 3000;

        if (armor.HelmID != null) // Not all sets have 4 armor pieces, so we'll need to check before creating a new shop entry
        {
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Armor] {armor.Name} Helm";
            int equipID = (int)armor.HelmID;
            uint eventFlagForQuantity = currentEventFlagID;
            currentEventFlagID += eventFlagStepSize;
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipTypeProtector);
            editor.SetShopLineupSellPrice(shopLineupId, helmSellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, armorSellQuantity);
        }
        if (armor.TorsoID != null) // Not all sets have 4 armor pieces, so we'll need to check before creating a new shop entry
        {
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Armor] {armor.Name} Torso";
            int equipID = (int)armor.TorsoID;
            uint eventFlagForQuantity = currentEventFlagID;
            currentEventFlagID += eventFlagStepSize;
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipTypeProtector);
            editor.SetShopLineupSellPrice(shopLineupId, torsoSellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, armorSellQuantity);
        }
        if (armor.GauntletsID != null) // Not all sets have 4 armor pieces, so we'll need to check before creating a new shop entry
        {
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Armor] {armor.Name} Gauntlets";
            int equipID = (int)armor.GauntletsID;
            uint eventFlagForQuantity = currentEventFlagID;
            currentEventFlagID += eventFlagStepSize;
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipTypeProtector);
            editor.SetShopLineupSellPrice(shopLineupId, gauntletsSellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, armorSellQuantity);
        }
        if (armor.GreavesID != null) // Not all sets have 4 armor pieces, so we'll need to check before creating a new shop entry
        {
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Armor] {armor.Name} Greaves";
            int equipID = (int)armor.GreavesID;
            uint eventFlagForQuantity = currentEventFlagID;
            currentEventFlagID += eventFlagStepSize;
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipTypeProtector);
            editor.SetShopLineupSellPrice(shopLineupId, greavesSellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, armorSellQuantity);
        }
        
        // Setup the Starlight Shards shop.
        byte starlightShardCostType = 2;
        List<string> ignoreTypes = new List<string> { "Whetblade", "Upgrade Stone", "Ash of War" };
        currentShopLineupId = 9200000;
        currentEventFlagID = 1056457000;
        for (int i = 0; i < shopItems.Count; i++)
        {
            string itemType = shopItems[i].Type;
            if (ignoreTypes.Contains(itemType))
            {
                continue;
            }
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Starlight Shop - {shopItems[i].Type}] {shopItems[i].Name}";
            int equipID = shopItems[i].ID;
            byte equipType = shopItems[i].EquipType;
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
            int sellPrice = 1;
            if (shopItems[i].Type == "Talisman")
            {
                if (shopItems[i].Cost > 40000)
                {
                    sellPrice = 3;
                }
                else if (shopItems[i].Cost > 20000)
                {
                    sellPrice = 2;
                }
            }
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipType);
            editor.SetShopLineupCostType(shopLineupId, starlightShardCostType);
            editor.SetShopLineupSellPrice(shopLineupId, sellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, sellQuantity);
        }

        // Setup the randomized weapons in the Starlight Shards shop. It has 3 total.
        // common variables
        int starlightWeaponCost = 5;
        short starlightWeaponSellPrice = 1;

        // The Starlight Shards shop shares weapons from the common pool (there can be duplicates)
        List<WeaponGroup> commonGroup = CsvReaderUtils.Read<WeaponGroup>($"{Constants.RandomizationGroupsDlc}/common.csv");
        List<int> targets = new() { 0, 1, 2 };
        List<int> replacements = new();
        for (int i = 0; i < commonGroup.Count; i++)
        {
            replacements.Add(commonGroup[i].WeaponID);
        }
        RandomizationGroup starlightShop = new(targets, replacements);
        urr.AddGroup("starlightShop", starlightShop);
        Dictionary<int, int> starlightShopReplacementsMapping = urr.RandomizeGroup("starlightShop");

        // Generate new shop rows and upgrade the weapon to its proper level (24 or 9, somber depending)
        Dictionary<int, Weapon> allWeapons = CsvReaderUtils.GetAllWeapons();
        Dictionary<int, CustomWeapon> allCustomWeapons = CsvReaderUtils.GetAllCustomWeapons();
        int currentCustomWeaponId = 9600069;
        for (int i = 0; i < targets.Count; i++)
        {
            int shopLineupId = currentShopLineupId++;
            uint eventFlagForQuantity = currentEventFlagID;
            currentEventFlagID += eventFlagStepSize;
            int replacementEquipID = starlightShopReplacementsMapping[targets[i]];
            int equipID;
            byte equipType;
            string weaponName;
            
            // Handle custom weapons differently
            if (allCustomWeapons.ContainsKey(replacementEquipID))
            {
                Debug.WriteLine("Custom weapon detected in shop");
                weaponName = allCustomWeapons[replacementEquipID].Name;
                equipID = currentCustomWeaponId;
                equipType = 5; // custom weapon
                int baseEquipID = editor.GetEquipCustomWeaponBaseWeaponId(replacementEquipID);
                int gemID = editor.GetEquipCustomWeaponGemId(replacementEquipID);

                // check if somber or smithing, upgrade accordingly
                int upgradeStoneType = editor.GetEquipWeaponMaterialSetId(baseEquipID);
                byte reinforceLevel = upgradeStoneType == 0 ? (byte)24 : (byte)9;

                editor.CreateNewEquipCustomWeaponRow(currentCustomWeaponId, allCustomWeapons[replacementEquipID].Name);
                editor.SetEquipCustomWeaponBaseWeaponId(currentCustomWeaponId, baseEquipID);
                editor.SetEquipCustomWeaponGemId(currentCustomWeaponId, gemID);
                editor.SetEquipCustomWeaponReinforceLevel(currentCustomWeaponId, reinforceLevel);
                currentCustomWeaponId += 2; // increment by 2 so it never ends in 0
            } else
            {
                weaponName = allWeapons[replacementEquipID].Name;
                equipID = replacementEquipID;
                equipType = 0;
                // check if somber or smithing, upgrade accordingly
                int upgradeStoneType = editor.GetEquipWeaponMaterialSetId(equipID);
                equipID = upgradeStoneType == 0 ? equipID + 24 : equipID + 9;
            }

            string name = $"[Merchant Millicent - Starlight Shop - Weapon] {weaponName}";
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipType);
            editor.SetShopLineupCostType(shopLineupId, starlightShardCostType);
            editor.SetShopLineupSellPrice(shopLineupId, starlightWeaponCost);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, starlightWeaponSellPrice);
        }
    }
    
    private void RandomizeGroups(ParamsEditor editor, ReplacementRandomizer urr)
    {
        // for now, I will explicitly read the data, but I'd like to generalize it based on the contents of the RandomizationGroups directory
        RandomizationGroup common = RandomizationGroupUtils.LoadFromCSVs($"{Constants.RandomizationGroupsDlc}/common.csv");
        RandomizationGroup bowsCrossbows = RandomizationGroupUtils.LoadFromCSVs($"{Constants.RandomizationGroupsDlc}/bows_crossbows.csv");
        RandomizationGroup perfumeBottles = RandomizationGroupUtils.LoadFromCSVs($"{Constants.RandomizationGroupsDlc}/perfume_bottles.csv");
        RandomizationGroup shield = RandomizationGroupUtils.LoadFromCSVs($"{Constants.RandomizationGroupsDlc}/shields.csv");

        // read in the params metadata
        Dictionary<int, List<ItemLotEntry>> weaponIdsToItemLotMap = ParamsEditor.GetWeaponIdsToItemLotMap();
        
        Dictionary<int, List<ItemLotEntry>> weaponIdsToItemLotEnemy = ParamsEditor.GetWeaponIdsToItemLotEnemy();

        Dictionary<int, List<int>> weaponIdsToShopLineup = ParamsEditor.GetWeaponIdsToShopLineup();

        Dictionary<int, CustomWeapon> allCustomWeapons = CsvReaderUtils.GetAllCustomWeapons();

        // reuse variable for all randomizing
        List<ItemLotEntry>? locations;
        List<int>? shopLocations;
        int category;
        byte equipType;

        // Randomize common weapon pool
        urr.AddGroup("common", common);
        Dictionary<int, int> commonReplacementsMapping = urr.RandomizeGroup("common");
        // do replacements
        foreach ((int target, int replacement) in commonReplacementsMapping)
        {
            // decide category
            category = allCustomWeapons.ContainsKey(replacement) ? 6 : 2;
            equipType = allCustomWeapons.ContainsKey(replacement) ? (byte)5 : (byte)0;

            // replace world pickups
            if (weaponIdsToItemLotMap.TryGetValue(target, out locations))
            {
                foreach (ItemLotEntry location in locations)
                {
                    foreach (int itemSlot in location.LotItems)
                    {
                        
                        editor.SetItemLotMapLotItemId(location.ID, itemSlot, replacement);
                        editor.SetItemLotMapCategory(location.ID, itemSlot, category);
                    }
                }
            }
            // replace enemy drops
            if (weaponIdsToItemLotEnemy.TryGetValue(target, out locations))
            {
                foreach (ItemLotEntry location in locations)
                {
                    foreach (int itemSlot in location.LotItems)
                    {
                        editor.SetItemLotEnemyLotItemId(location.ID, itemSlot, replacement);
                        editor.SetItemLotEnemyCategory(location.ID, itemSlot, category);
                    }
                }
            }
            // replace shop items
            if (weaponIdsToShopLineup.TryGetValue(target, out shopLocations)) 
            {
                foreach (int shopLineupId in shopLocations)
                {
                    editor.SetShopLineupEquipId(shopLineupId, replacement);
                    editor.SetShopLineupEquipType(shopLineupId, equipType);
                }
            }
        }

        // Randomize bows and crossbows
        urr.AddGroup("bowsCrossbows", bowsCrossbows);
        Dictionary<int, int> bowsCrossbowsReplacementsMapping = urr.RandomizeGroup("bowsCrossbows");
        // do replacements
        foreach ((int target, int replacement) in bowsCrossbowsReplacementsMapping)
        {
            // decide category
            category = allCustomWeapons.ContainsKey(replacement) ? 6 : 2;
            equipType = allCustomWeapons.ContainsKey(replacement) ? (byte)5 : (byte)0;

            // replace world pickups
            if (weaponIdsToItemLotMap.TryGetValue(target, out locations))
            {
                foreach (ItemLotEntry location in locations)
                {
                    foreach (int itemSlot in location.LotItems)
                    {
                        editor.SetItemLotMapLotItemId(location.ID, itemSlot, replacement);
                        editor.SetItemLotMapCategory(location.ID, itemSlot, category);
                    }
                }
            }
            // replace enemy drops
            if (weaponIdsToItemLotEnemy.TryGetValue(target, out locations))
            {
                foreach (ItemLotEntry location in locations)
                {
                    foreach (int itemSlot in location.LotItems)
                    {
                        editor.SetItemLotEnemyLotItemId(location.ID, itemSlot, replacement);
                        editor.SetItemLotEnemyCategory(location.ID, itemSlot, category);
                    }
                }
            }
            // replace shop items
            if (weaponIdsToShopLineup.TryGetValue(target, out shopLocations))
            {
                foreach (int shopLineupId in shopLocations)
                {
                    editor.SetShopLineupEquipId(shopLineupId, replacement);
                    editor.SetShopLineupEquipType(shopLineupId, equipType);
                }
            }
        }

        // Randomize perfume bottles
        urr.AddGroup("perfumeBottles", perfumeBottles);
        Dictionary<int, int> perfumeBottlesReplacementsMapping = urr.RandomizeGroup("perfumeBottles");
        // do replacements
        foreach ((int target, int replacement) in perfumeBottlesReplacementsMapping)
        {
            // decide category
            category = allCustomWeapons.ContainsKey(replacement) ? 6 : 2;
            equipType = allCustomWeapons.ContainsKey(replacement) ? (byte)5 : (byte)0;

            // replace world pickups
            if (weaponIdsToItemLotMap.TryGetValue(target, out locations))
            {
                foreach (ItemLotEntry location in locations)
                {
                    foreach (int itemSlot in location.LotItems)
                    {
                        editor.SetItemLotMapLotItemId(location.ID, itemSlot, replacement);
                        editor.SetItemLotMapCategory(location.ID, itemSlot, category);
                    }
                }
            }
            // replace enemy drops
            if (weaponIdsToItemLotEnemy.TryGetValue(target, out locations))
            {
                foreach (ItemLotEntry location in locations)
                {
                    foreach (int itemSlot in location.LotItems)
                    {
                        editor.SetItemLotEnemyLotItemId(location.ID, itemSlot, replacement);
                        editor.SetItemLotEnemyCategory(location.ID, itemSlot, category);
                    }
                }
            }
            // replace shop items
            if (weaponIdsToShopLineup.TryGetValue(target, out shopLocations))
            {
                foreach (int shopLineupId in shopLocations)
                {
                    editor.SetShopLineupEquipId(shopLineupId, replacement);
                    editor.SetShopLineupEquipType(shopLineupId, equipType);
                }
            }
        }

        // Randomize shields
        urr.AddGroup("shields", shield);
        Dictionary<int, int> shieldsReplacementsMapping = urr.RandomizeGroup("shields");
        // do replacements
        foreach ((int target, int replacement) in shieldsReplacementsMapping)
        {
            // decide category
            category = allCustomWeapons.ContainsKey(replacement) ? 6 : 2;
            equipType = allCustomWeapons.ContainsKey(replacement) ? (byte)5 : (byte)0;

            // replace world pickups
            if (weaponIdsToItemLotMap.TryGetValue(target, out locations))
            {
                foreach (ItemLotEntry location in locations)
                {
                    foreach (int itemSlot in location.LotItems)
                    {
                        editor.SetItemLotMapLotItemId(location.ID, itemSlot, replacement);
                        editor.SetItemLotMapCategory(location.ID, itemSlot, category);
                    }
                }
            }
            // replace enemy drops
            if (weaponIdsToItemLotEnemy.TryGetValue(target, out locations))
            {
                foreach (ItemLotEntry location in locations)
                {
                    foreach (int itemSlot in location.LotItems)
                    {
                        editor.SetItemLotEnemyLotItemId(location.ID, itemSlot, replacement);
                        editor.SetItemLotEnemyCategory(location.ID, itemSlot, category);
                    }
                }
            }
            // replace shop items
            if (weaponIdsToShopLineup.TryGetValue(target, out shopLocations))
            {
                foreach (int shopLineupId in shopLocations)
                {
                    editor.SetShopLineupEquipId(shopLineupId, replacement);
                    editor.SetShopLineupEquipType(shopLineupId, equipType);
                }
            }
        }
    }
}
