// SPDX-License-Identifier: GPL-3.0-only
using Athena.Models;
using EldenRingParamsEditor;
using UniversalReplacementRandomizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Animation;

namespace Athena.Utilities;

internal class ReplacementUtils
{
    public static void RandomizeAndReplaceWeapons(ParamsEditor editor, ReplacementRandomizerMN urr, string groupFilePath)
    {
        // The file must exist
        if (!File.Exists(groupFilePath))
        {
            throw new FileNotFoundException($"Could not find file {groupFilePath}");
        }

        // The string for this group will be the file name
        string fileName = Path.GetFileName(groupFilePath);

        // Randomize the group
        List<WeaponGroupMN> weapons = CsvReaderUtils.Read<WeaponGroupMN>(groupFilePath);
        RandomizationGroupMN weaponsMN = new(weapons.Count, weapons.Count);
        urr.AddGroup(fileName, weaponsMN);
        int[] replacementIndexes = urr.RandomizeGroup(fileName);

        // Now apply replacements
        ApplyWeaponsReplacements(editor, replacementIndexes, weapons);
    }

    public static void ApplyWeaponsReplacements(ParamsEditor editor, int[] replacementIndexes, List<WeaponGroupMN> groupList)
    {
        List<ItemLotEntry>? locations;
        List<int>? shopLocations;
        int category;
        byte equipType;

        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            int target = groupList[i].WeaponID;
            int replacement = groupList[replacementIndexes[i]].WeaponID;

            // decide category and equip type
            if (groupList[replacementIndexes[i]].IsCustomWeapon)
            {
                category = 6;
                equipType = (byte)5;
            }
            else
            {
                category = 2;
                equipType = (byte)0;
            }

            // replace world pickups
            Dictionary<int, List<ItemLotEntry>> weaponIdsToItemLotMap = editor.GetWeaponIdsToItemLotMap();
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
            Dictionary<int, List<ItemLotEntry>> weaponIdsToItemLotEnemy = editor.GetWeaponIdsToItemLotEnemy();
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
            Dictionary<int, List<int>> weaponIdsToShopLineup = editor.GetWeaponIdsToShopLineup();
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

    public static void RandomizeAndReplace<T>(ParamsEditor editor, ReplacementRandomizerMN urr, string groupFilePath)
        where T : IGameItem
    {
        // The file must exist
        if (!File.Exists(groupFilePath))
        {
            throw new FileNotFoundException($"Could not find file {groupFilePath}");
        }

        // The string for this group will be the file name
        string fileName = Path.GetFileName(groupFilePath);

        // Randomize the group
        List<T> weapons = CsvReaderUtils.Read<T>(groupFilePath);
        RandomizationGroupMN weaponsMN = new(weapons.Count, weapons.Count);
        urr.AddGroup(fileName, weaponsMN);
        int[] replacementIndexes = urr.RandomizeGroup(fileName);

        // Now apply replacements
        ApplyReplacements(editor, replacementIndexes, weapons);
    }

    public static void ApplyReplacements<T>(ParamsEditor editor, int[] replacementIndexes, List<T> groupList)
        where T : IGameItem
    {
        List<ItemLotEntry>? locations;
        List<int>? shopLocations;

        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            T target = groupList[i];
            T replacement = groupList[replacementIndexes[i]];

            // replace world pickups
            Dictionary<int, List<ItemLotEntry>> weaponIdsToItemLotMap = editor.GetWeaponIdsToItemLotMap();
            if (weaponIdsToItemLotMap.TryGetValue(target.ID, out locations))
            {
                foreach (ItemLotEntry location in locations)
                {
                    foreach (int itemSlot in location.LotItems)
                    {
                        editor.SetItemLotMapLotItemId(location.ID, itemSlot, replacement.ID);
                        editor.SetItemLotMapCategory(location.ID, itemSlot, replacement.Category);
                    }
                }
            }

            // replace enemy drops
            Dictionary<int, List<ItemLotEntry>> weaponIdsToItemLotEnemy = editor.GetWeaponIdsToItemLotEnemy();
            if (weaponIdsToItemLotEnemy.TryGetValue(target.ID, out locations))
            {
                foreach (ItemLotEntry location in locations)
                {
                    foreach (int itemSlot in location.LotItems)
                    {
                        editor.SetItemLotEnemyLotItemId(location.ID, itemSlot, replacement.ID);
                        editor.SetItemLotEnemyCategory(location.ID, itemSlot, replacement.Category);
                    }
                }
            }

            // replace shop items
            Dictionary<int, List<int>> weaponIdsToShopLineup = editor.GetWeaponIdsToShopLineup();
            if (weaponIdsToShopLineup.TryGetValue(target.ID, out shopLocations))
            {
                foreach (int shopLineupId in shopLocations)
                {
                    editor.SetShopLineupEquipId(shopLineupId, replacement.ID);
                    editor.SetShopLineupEquipType(shopLineupId, replacement.EquipType);
                }
            }
        }
    }
}
