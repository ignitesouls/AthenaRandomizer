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
            _initStartingClasses();
            _modifyADMFlasks();
            _paramsEditor.WriteToRegulationPath(Constants.RegulationOutDlc);
        }

        // Set all stats to 10 except vig to 50
        // Remove all starting gear and spells
        // Give every class 10 starlight shards to exchange for items
        private void _initStartingClasses()
        {
            if (_paramsEditor == null)
            {
                throw new Exception("Failed: _paramsEditor hasn't been initialized");
            }
            for (int i = 0; i < Constants.TotalStartingClasses; i++)
            {
                int charaInitId = Constants.VagabondCharaInitId + i;
                _paramsEditor.SetInitialRuneLevel(charaInitId, 1);
                _paramsEditor.SetInitialRunes(charaInitId, 160000);
                _paramsEditor.SetInitialVigor(charaInitId, 50);
                _paramsEditor.SetInitialMind(charaInitId, 10);
                _paramsEditor.SetInitialEndurance(charaInitId, 10);
                _paramsEditor.SetInitialStrength(charaInitId, 10);
                _paramsEditor.SetInitialDexterity(charaInitId, 10);
                _paramsEditor.SetInitialIntelligence(charaInitId, 10);
                _paramsEditor.SetInitialFaith(charaInitId, 10);
                _paramsEditor.SetInitialArcane(charaInitId, 10);
                _paramsEditor.SetInitialEquipWepRight(charaInitId, 0, Constants.ClubItemId);
                _paramsEditor.SetInitialEquipWepLeft(charaInitId, 0, -1);
                for (int j = 1; j < 2; j++)
                {
                    _paramsEditor.SetInitialEquipWepRight(charaInitId, j, -1);
                    _paramsEditor.SetInitialEquipWepLeft(charaInitId, j, -1);
                }
                _paramsEditor.SetInitialEquipHelm(charaInitId, -1);
                _paramsEditor.SetInitialEquipTorso(charaInitId, -1);
                _paramsEditor.SetInitialEquipArm(charaInitId, -1);
                _paramsEditor.SetInitialEquipLeg(charaInitId, -1);
                for (int j = 0; j < 4; j++)
                {
                    _paramsEditor.SetInitialEquipAmmunition(charaInitId, j, -1, 0);
                }
                for (int j = 0; j < 7; j++)
                {
                    _paramsEditor.SetInitialEquipSpell(charaInitId, j, -1);
                }
                // Starlight Shards
                _paramsEditor.SetInitialEquipItem(charaInitId, 9, 1290);
                _paramsEditor.SetInitialEquipItemAmount(charaInitId, 9, 10);
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
