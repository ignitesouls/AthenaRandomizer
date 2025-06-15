// SPDX-License-Identifier: GPL-3.0-only
using Athena.Models;
using EldenRingParamsEditor;
using System.IO;
using UniversalReplacementRandomizer;

namespace Athena.Utilities;

internal struct ReplacementGroup<T> where T : IGameItem
{
    public List<T> Targets { get; }
    public List<T> Replacements { get; }

    public ReplacementGroup(string directoryPath)
    {
        if (!File.Exists(Path.Combine(directoryPath, "targets.csv")))
        {
            throw new FileNotFoundException("targets.csv is required in group directory.");
        }

        Targets = CsvReaderUtils.Read<T>(Path.Combine(directoryPath, "targets.csv"));

        string replacementsPath = Path.Combine(directoryPath, "replacements.csv");
        if (File.Exists(replacementsPath))
        {
            Replacements = CsvReaderUtils.Read<T>(replacementsPath);
        }
        else
        {
            Replacements = new List<T>(Targets); // fallback: self-replacement
        }
    }
}

internal class ReplacementUtils
{
    public static void ApplyReplacements<T>(ParamsEditor editor, int[] replacementIndexes, List<T> targets, List<T> replacements)
        where T : IGameItem
    {
        List<ItemLotEntry>? locations;
        List<int>? shopLocations;

        for (int i = 0; i < replacementIndexes.Length; i++)
        {
            T target = targets[i];
            T replacement = replacements[replacementIndexes[i]];

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

    public static void RandomizeAndReplaceFile<T>(ParamsEditor editor,
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
        ApplyReplacements(editor, replacementIndexes, group, group);
    }

    public static void RandomizeAndReplaceDir<T>(ParamsEditor editor,
                                                 OptimizedReplacementRandomizer urr,
                                                 string groupDirectoryPath)
    where T : IGameItem
    {
        if (!Directory.Exists(groupDirectoryPath))
        {
            throw new DirectoryNotFoundException($"Could not find group directory: {groupDirectoryPath}");
        }

        string groupName = Path.GetFileName(Path.TrimEndingDirectorySeparator(groupDirectoryPath));

        var group = new ReplacementGroup<T>(groupDirectoryPath);
        var randoGroup = new OptimizedRandomizationGroup(group.Targets.Count, group.Replacements.Count);
        urr.AddGroup(groupName, randoGroup);

        int[] replacementIndexes = urr.RandomizeGroup(groupName);
        ApplyReplacements(editor, replacementIndexes, group.Targets, group.Replacements);
    }

    public static void Randomize<T>(ParamsEditor editor,
                                    OptimizedReplacementRandomizer urr,
                                    string rootDir)
        where T : IGameItem
    {
        (List<string> files, List<string> directories) = CsvDirectoryUtils.GetCsvStructure(rootDir);

        foreach (var file in files)
        {
            RandomizeAndReplaceFile<GameItemModel>(editor, urr, file);
        }

        foreach (var directory in directories)
        {
            RandomizeAndReplaceDir<GameItemModel>(editor, urr, directory);
        }
    }
}
