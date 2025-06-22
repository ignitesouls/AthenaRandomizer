// SPDX-License-Identifier: GPL-3.0-only
using Athena.Config;
using Athena.Models;
using Athena.Utilities;
using EldenRingParamsEditor;
using SoulsFormats;
using System.Diagnostics;
using System.IO;
using UniversalReplacementRandomizer;

namespace Athena.Services;

public class RandomizerServiceBaseDlc
{
    private const string SeedManagerPrefix = "basedlc";
    RandomizerServiceStartingClass randomizerServiceStartingClass = new();

    public void RandomizeBaseDlc(int? baseSeed,
                                Action<int?>? updateBaseSeedCallback,
                                Action<int?>? updateRandomizedSeedCallback)
    {
        using DebugTimer _ = new DebugTimer("RandomizeBaseDlc");

        var editor = ParamsEditor.ReadFromRegulationPath(Constants.RegulationInBaseDlc);
        var menuBndEditor = MenuBndEditorService.ReadFromMenuBndFilePath(Constants.MenuBndInBaseDlc);

        var urr = new OptimizedReplacementRandomizer(SeedManagerPrefix, baseSeed);
        if (baseSeed == null)
        {
            updateBaseSeedCallback?.Invoke(urr.GetBaseSeed());
        }

        RandomizeStartingClassesBaseDlc(editor, menuBndEditor, urr);
        //ReplacementUtils.RandomizeWeapons<GameItemModel>(editor, urr, $"{Constants.RandomizationGroupsBaseDlc}/guaranteed_weapons");

        editor.WriteToRegulationPath(Constants.RegulationOutBaseDlc);
        menuBndEditor.WriteToMenuBndFilePath(Constants.MenuBndOutBaseDlc);

        updateRandomizedSeedCallback?.Invoke(urr.GetBaseSeed());
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

            menuBndEditor.SetClassDescription(i, classDescription);
        }
    }
}
