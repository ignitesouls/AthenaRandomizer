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

public class RandomizerServiceBase
{
    private const string SeedManagerPrefix = "base";
    RandomizerServiceStartingClass randomizerServiceStartingClass = new();

    public void RandomizeBase(int? baseSeed,
                              Action<int?>? updateBaseSeedCallback,
                              Action<int?>? updateRandomizedSeedCallback)
    {
        using DebugTimer _ = new DebugTimer("RandomizeBase");

        var editor = ParamsEditor.ReadFromRegulationPath(Constants.RegulationInBase);
        var menuBndEditor = MenuBndEditorService.ReadFromMenuBndFilePath(Constants.MenuBndInBase);

        var urr = new OptimizedReplacementRandomizer(SeedManagerPrefix, baseSeed);
        if (baseSeed == null)
        {
            updateBaseSeedCallback?.Invoke(urr.GetBaseSeed());
        }

        RandomizeStartingClassesBase(editor, menuBndEditor, urr);
        RandomizeWeaponsBase(editor, urr);
        RandomizePerfumeBottles(editor, urr);

        editor.WriteToRegulationPath(Constants.RegulationOutBase);
        menuBndEditor.WriteToMenuBndFilePath(Constants.MenuBndOutBase);

        updateRandomizedSeedCallback?.Invoke(urr.GetBaseSeed());
    }

    private void RandomizeStartingClassesBase(ParamsEditor editor, MenuBndEditorService menuBndEditor, OptimizedReplacementRandomizer urr)
    {
        using DebugTimer _ = new DebugTimer("RandomizeStartingClassesBase");

        var classStatAllocations = randomizerServiceStartingClass.GenerateAllClassStats(urr);
        var armorSetAllocations = randomizerServiceStartingClass.GenerateArmorSets(urr, $"{Constants.Misc}/base/starting_classes");
        var weaponSetAllocations = randomizerServiceStartingClass.GenerateWeaponSets(urr, $"{Constants.Misc}/base/starting_classes");

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
                List<GameItemModel> sorceries = CsvReaderUtils.Read<GameItemModel>($"{Constants.Misc}/base/starting_classes/sorceries.csv");
                Random rng = urr.GetSeedManager().GetRandomByKey("starting_sorceries");
                GameItemModel sorcery = sorceries[rng.Next(sorceries.Count)];
                editor.SetInitialEquipSpell(charaInitId, 0, sorcery.ID);
                editor.SetInitialEquipWepLeft(charaInitId, 1, Constants.GlintstoneStaffItemId);
                classDescription += $", Glintstone Staff, {sorcery.Name}";
            }

            // guaranteed incantation / seal
            if (i == 5) // prophet
            {
                List<GameItemModel> incantations = CsvReaderUtils.Read<GameItemModel>($"{Constants.Misc}/base/starting_classes/incantations.csv");
                Random rng = urr.GetSeedManager().GetRandomByKey("starting_incantations");
                GameItemModel incantation = incantations[rng.Next(incantations.Count)];
                editor.SetInitialEquipSpell(charaInitId, 0, incantation.ID);
                editor.SetInitialEquipWepLeft(charaInitId, 1, Constants.FingerSealItemId);
                classDescription += $", Finger Seal, {incantation.Name}";
            }

            menuBndEditor.SetClassDescription(i, classDescription);
        }
    }

    public void RandomizeWeaponsBase(ParamsEditor editor, OptimizedReplacementRandomizer urr)
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
                                                  $"{Constants.RandomizationGroupsBase}/spells",
                                                  goodsIdsToItemLotMap,
                                                  goodsIdsToItemLotEnemy,
                                                  goodsIdsToShopLineup);

        // chance weapons (randomized within classes)
        ReplacementUtils.RandomizeItemLotEnemy<WeaponModel>(editor,
                                                            urr,
                                                            $"{Constants.RandomizationGroupsBase}/chance_weapons",
                                                            weaponIdsToItemLotEnemy);


        // guaranteed and map weapons (randomized within classes)
        ReplacementUtils.Randomize<GameItemModel>(editor,
                                                  urr,
                                                  $"{Constants.RandomizationGroupsBase}/map_guaranteed_weapons",
                                                  weaponIdsToItemLotMap,
                                                  weaponIdsToItemLotEnemy,
                                                  weaponIdsToShopLineup);

        // remembrance weapons
        ReplacementUtils.RandomizeAndReplaceShopLineupFile<WeaponModel>(editor,
                                                                       urr,
                                                                       $"{Constants.RandomizationGroupsBase}/remembrances/weapons.csv",
                                                                       weaponIdsToShopLineup);
        
        // remembrance sorceries
        ReplacementUtils.RandomizeAndReplaceShopLineupFile<WeaponModel>(editor,
                                                                       urr,
                                                                       $"{Constants.RandomizationGroupsBase}/remembrances/sorceries.csv",
                                                                       goodsIdsToShopLineup);
        
        // remembrance incantations
        ReplacementUtils.RandomizeAndReplaceShopLineupFile<WeaponModel>(editor,
                                                                       urr,
                                                                       $"{Constants.RandomizationGroupsBase}/remembrances/incantations.csv",
                                                                       goodsIdsToShopLineup);

        // shop weapons
        ReplacementUtils.RandomizeAndReplaceShopLineupDir<WeaponModel>(editor,
                                                                       urr,
                                                                       $"{Constants.RandomizationGroupsBase}/shop_weapons",
                                                                       weaponIdsToShopLineup);
    }

    private void RandomizePerfumeBottles(ParamsEditor editor, OptimizedReplacementRandomizer urr)
    {
        List<int> validLocationIDs = new List<int>()
        {
           16000110, // Volcano manor
           31180000, // Perfumer's Grotto
           1036510020, // Perfumer's Ruins (near Omenkiller)
           1039540040, // Shaded Castle
           // 1048380010 // Caelid
        };
        List<int> perfumeBottleIDs = new List<int>()
        {
            61500000, // Firespark
            61510000, // Chilling Mist
            61520000, // Frenzy Flame
            61530000, // Lightning
            61540000, // Deadly Poison
        };
    }
}
