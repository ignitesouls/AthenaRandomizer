// SPDX-License-Identifier: GPL-3.0-only
using Athena.Models;
using UniversalReplacementRandomizer;

namespace Athena.Utilities;

public class RandomizationGroupUtils
{
    // replacementsFilePath is optional. default behavior is to copy targets into replacements, which is the same as just shuffling the group.
    public static RandomizationGroup LoadFromCSVs(string targetsFilePath, string? replacementsFilePath = null)
    {
        List<int> targets = new();
        List<WeaponGroup> targetsCsv = CsvReaderUtils.Read<WeaponGroup>(targetsFilePath);
        for (int i = 0; i < targetsCsv.Count; i++)
        {
            targets.Add(targetsCsv[i].WeaponID);
        }

        List<int> replacements = new();
        if (replacementsFilePath != null)
        {
            List<WeaponGroup> replacementsCsv = CsvReaderUtils.Read<WeaponGroup>(replacementsFilePath);
            for (int i = 0; i < replacementsCsv.Count; i++)
            {
                replacements.Add(replacementsCsv[i].WeaponID);
            }
        }
        else
        {
            replacements = new(targets);
        }
        
        return new RandomizationGroup(targets, replacements);
    }
}
