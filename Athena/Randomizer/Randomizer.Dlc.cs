using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athena.Config;
using Athena.Core;

namespace Athena.Randomizer
{
    public partial class Randomizer
    {
        private void _randomizeDlc()
        {
            _paramsEditor = ParamsEditor.ReadFromRegulationPath(Constants.RegulationInDlc);
            _initDlcShop();
            //_modifyADMFlasks();
            _initStartingClasses();
            _paramsEditor.WriteToRegulationPath(Constants.RegulationOutDlc);
        }

        private void _initStartingClasses()
        {
            if (_paramsEditor == null)
            {
                throw new Exception("Failed: _paramsEditor hasn't been initialized");
            }
            for (int i = 0; i < Constants.TotalStartingClasses; i++)
            {
                int charaInitId = Constants.VagabondCharaInitId + i;
                // reset all stats
                _paramsEditor.SetInitialRuneLevel(charaInitId, 1);
                _paramsEditor.SetInitialVigor(charaInitId, 50);
                _paramsEditor.SetInitialMind(charaInitId, 10);
                _paramsEditor.SetInitialEndurance(charaInitId, 10);
                _paramsEditor.SetInitialStrength(charaInitId, 10);
                _paramsEditor.SetInitialDexterity(charaInitId, 10);
                _paramsEditor.SetInitialIntelligence(charaInitId, 10);
                _paramsEditor.SetInitialFaith(charaInitId, 10);
                _paramsEditor.SetInitialArcane(charaInitId, 10);
                _paramsEditor.SetInitialRunes(charaInitId, 160000);

                // clear all initial equipment
                for (int j = 0; j < 2; j++)
                {
                    _paramsEditor.SetInitialEquipWepRight(charaInitId, j, -1);
                    _paramsEditor.SetInitialEquipWepLeft(charaInitId, j, -1);
                }
                for (int j = 0; j < 4; j++)
                {
                    _paramsEditor.SetInitialEquipAmmunition(charaInitId, j, -1, 0);
                }
                for (int j = 0; j < 7; j++)
                {
                    _paramsEditor.SetInitialEquipSpell(charaInitId, j, -1);
                }
                _paramsEditor.SetInitialEquipHelm(charaInitId, -1);
                _paramsEditor.SetInitialEquipTorso(charaInitId, -1);
                _paramsEditor.SetInitialEquipArm(charaInitId, -1);
                _paramsEditor.SetInitialEquipLeg(charaInitId, -1);

                // clear all items
                for (int j = 0; j < 10; j++)
                {
                    _paramsEditor.SetInitialEquipItem(charaInitId, j, -1);
                    _paramsEditor.SetInitialEquipItemAmount(charaInitId, j, 0);
                }

                // add initial weapons (club +0, staff +25, seal +25)
                _paramsEditor.SetInitialEquipWepRight(charaInitId, 0, Constants.ClubItemId);
                _paramsEditor.SetInitialEquipWepLeft(charaInitId, 0, 33000025);
                _paramsEditor.SetInitialEquipWepLeft(charaInitId, 1, 34000025);

                // Starlight Shards (experimental edition, comment out for regular)
                //_paramsEditor.SetInitialEquipItem(charaInitId, 9, 1290);
                //_paramsEditor.SetInitialEquipItemAmount(charaInitId, 9, 10);

            }
        }

        private void _initDlcShop()
        {
            if (_paramsEditor == null)
            {
                throw new Exception("Failed: _paramsEditor hasn't been initialized");
            }

            // set EventFlagForStock for our DLC shops
            // smithing stones
            for (int i = 0; i < Constants.DlcShopStonesIdCount; i++)
            {
                int shopLineupId = Constants.DlcShopStonesIdStart + i;
                _paramsEditor.SetShopLineupEventFlagForStock(
                    shopLineupId,
                    Constants.DlcShopStonesIdBaseEventFlagForStock + (uint)i * 10
                );
            }
            // talismans
            for (int i = 0; i < Constants.DlcShopTalismansIdCount; i++)
            {
                int shopLineupId = Constants.DlcShopTalismansIdStart + i;
                _paramsEditor.SetShopLineupEventFlagForStock(
                    shopLineupId,
                    Constants.DlcShopTalismansIdBaseEventFlagForStock + (uint)i * 10
                );
            }
            // key items
            for (int i = 0; i < Constants.DlcShopKeyItemsIdCount; i++)
            {
                int shopLineupId = Constants.DlcShopKeyItemsIdStart + i;
                _paramsEditor.SetShopLineupEventFlagForStock(
                    shopLineupId,
                    Constants.DlcShopKeyItemsIdBaseEventFlagForStock + (uint)i * 10
                );
            }
            // consumables
            for (int i = 0; i < Constants.DlcShopConsumablesIdCount; i++)
            {
                int shopLineupId = Constants.DlcShopConsumablesIdStart + i;
                _paramsEditor.SetShopLineupEventFlagForStock(
                    shopLineupId,
                    Constants.DlcShopConsumablesIdBaseEventFlagForStock + (uint)i * 10
                );
            }
        }

        private void _modifyADMFlasks()
        {
            if (_paramsEditor == null)
            {
                throw new Exception("Failed: _paramsEditor hasn't been initialized");
            }
            int admId = 2024070;
            _paramsEditor.SetInitialMaxHpFlasks(admId, 20);
            _paramsEditor.SetInitialEquipItemAmount(admId, 2, 20);
        }
    }
}
