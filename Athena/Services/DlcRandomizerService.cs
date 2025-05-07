using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athena.Core;
using Athena.Config;

namespace Athena.Services;

public class DlcRandomizerService
{
    public void RandomizeDlc()
    {
        var editor = ParamsEditor.ReadFromRegulationPath(Constants.RegulationInDlc);

        InitDlcShop(editor);
        InitStartingClasses(editor);

        editor.WriteToRegulationPath(Constants.RegulationOutDlc);
    }

    private void InitStartingClasses(ParamsEditor editor)
    {
        for (int i = 0; i < Constants.TotalStartingClasses; i++)
        {
            int charaInitId = Constants.VagabondCharaInitId + i;
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
            editor.SetInitialRunes(charaInitId, 160000);

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

            // add initial weapons (club +0, staff +25, seal +25)
            editor.SetInitialEquipWepRight(charaInitId, 0, Constants.ClubItemId);
            editor.SetInitialEquipWepLeft(charaInitId, 0, 33000025);
            editor.SetInitialEquipWepLeft(charaInitId, 1, 34000025);

            // Starlight Shards (experimental edition, comment out for regular)
            //editor.SetInitialEquipItem(charaInitId, 9, 1290);
            //editor.SetInitialEquipItemAmount(charaInitId, 9, 10);

        }
    }

    private void InitDlcShop(ParamsEditor editor)
    {
        // set EventFlagForStock for our DLC shops
        // smithing stones
        for (int i = 0; i < Constants.DlcShopStonesIdCount; i++)
        {
            int shopLineupId = Constants.DlcShopStonesIdStart + i;
            editor.SetShopLineupEventFlagForStock(
                shopLineupId,
                Constants.DlcShopStonesIdBaseEventFlagForStock + (uint)i * 10
            );
        }
        // talismans
        for (int i = 0; i < Constants.DlcShopTalismansIdCount; i++)
        {
            int shopLineupId = Constants.DlcShopTalismansIdStart + i;
            editor.SetShopLineupEventFlagForStock(
                shopLineupId,
                Constants.DlcShopTalismansIdBaseEventFlagForStock + (uint)i * 10
            );
        }
        // key items
        for (int i = 0; i < Constants.DlcShopKeyItemsIdCount; i++)
        {
            int shopLineupId = Constants.DlcShopKeyItemsIdStart + i;
            editor.SetShopLineupEventFlagForStock(
                shopLineupId,
                Constants.DlcShopKeyItemsIdBaseEventFlagForStock + (uint)i * 10
            );
        }
        // consumables
        for (int i = 0; i < Constants.DlcShopConsumablesIdCount; i++)
        {
            int shopLineupId = Constants.DlcShopConsumablesIdStart + i;
            editor.SetShopLineupEventFlagForStock(
                shopLineupId,
                Constants.DlcShopConsumablesIdBaseEventFlagForStock + (uint)i * 10
            );
        }
    }
}
