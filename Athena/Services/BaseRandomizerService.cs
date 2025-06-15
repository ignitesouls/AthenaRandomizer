// SPDX-License-Identifier: GPL-3.0-only
using Athena.Config;
using Athena.Utilities;
using Athena.Models;
using EldenRingParamsEditor;
using System.Diagnostics;
using UniversalReplacementRandomizer;

namespace Athena.Services;

public class BaseRandomizerService
{
    private const string SeedManagerPrefix = "base";

    public void RandomizeBase(int? baseSeed,
                              Action<int?>? updateBaseSeedCallback,
                              Action<int?>? updateRandomizedSeedCallback)
    {
        using DebugTimer _ = new DebugTimer("RandomizeBase");

        var editor = ParamsEditor.ReadFromRegulationPath(Constants.RegulationInBase);

        var urr = new OptimizedReplacementRandomizer(SeedManagerPrefix, baseSeed);
        if (baseSeed == null)
        {
            updateBaseSeedCallback?.Invoke(urr.GetBaseSeed());
        }

        InitStartingClasses(editor);
        ReplacementUtils.Randomize<GameItemModel>(editor, urr, Constants.RandomizationGroupsBase);

        editor.WriteToRegulationPath(Constants.RegulationOutBase);

        updateRandomizedSeedCallback?.Invoke(urr.GetBaseSeed());
    }

    private void InitStartingClasses(ParamsEditor editor)
    {
        using DebugTimer _ = new DebugTimer("InitStartingClasses");
    }
}
