// SPDX-License-Identifier: GPL-3.0-only
using Athena.Models;
using EldenRingParamsEditor;
using UniversalReplacementRandomizer;
using System.IO;

namespace Athena.Utilities;

internal class ReplacementUtils
{
    public static void RandomizeAndReplace<T>(ParamsEditor editor,
                                              OptimizedReplacementRandomizer urr,
                                              string groupFilePath)
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
        List<T> group = CsvReaderUtils.Read<T>(groupFilePath);
        OptimizedRandomizationGroup randoGroup = new(group.Count, group.Count);
        urr.AddGroup(fileName, randoGroup);
        int[] replacementIndexes = urr.RandomizeGroup(fileName);

        // Now apply replacements
        ApplyReplacements(editor, replacementIndexes, group);
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
