using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athena.Config;

namespace Athena.Core
{
    internal partial class ParamsEditor
    {
        public void SetInitialRunes(int charaInitId, int initialRunes)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexRunesAmount, initialRunes);
        }

        public void SetInitialRuneLevel(int charaInitId, Int16 initialRuneLevel)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexRuneLevel, initialRuneLevel);
        }

        public void SetInitialVigor(int charaInitId, byte startingVigor)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexVigor, startingVigor);
        }

        public void SetInitialMind(int charaInitId, byte startingMind)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexMind, startingMind);
        }

        public void SetInitialEndurance(int charaInitId, byte startingEndurance)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexEndurance, startingEndurance);
        }

        public void SetInitialStrength(int charaInitId, byte startingStrength)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexStrength, startingStrength);
        }

        public void SetInitialDexterity(int charaInitId, byte startingDexterity)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexDexterity, startingDexterity);
        }

        public void SetInitialIntelligence(int charaInitId, byte startingIntelligence)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexIntelligence, startingIntelligence);
        }

        public void SetInitialFaith(int charaInitId, byte startingFaith)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexFaith, startingFaith);
        }

        public void SetInitialArcane(int charaInitId, byte startingArcane)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexArcane, startingArcane);
        }

        public void SetInitialEquipHelm(int charaInitId, int helmId)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexEquipHelm, helmId);
        }

        public void SetInitialEquipTorso(int charaInitId, int torsoId)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexEquipTorso, torsoId);
        }

        public void SetInitialEquipArm(int charaInitId, int armId)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexEquipArm, armId);
        }

        public void SetInitialEquipLeg(int charaInitId, int legId)
        {
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexEquipLeg, legId);
        }

        public void SetInitialEquipWepRight(int charaInitId, int weaponEquipSlot, int weaponId)
        {
            int colIndex;
            if (weaponEquipSlot == 0) colIndex = Constants.ColIndexEquipWepRight1;
            else if (weaponEquipSlot == 1) colIndex = Constants.ColIndexEquipWepRight2;
            else if (weaponEquipSlot == 2) colIndex = Constants.ColIndexEquipWepRight3;
            else
            {
                throw new Exception($"Invalid equip slot {weaponEquipSlot}. Choose a value in [0, 1, 2]");
            }
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, colIndex, weaponId);
        }

        public void SetInitialEquipWepLeft(int charaInitId, int weaponEquipSlot, int weaponId)
        {
            int colIndex;
            if (weaponEquipSlot == 0) colIndex = Constants.ColIndexEquipWepLeft1;
            else if (weaponEquipSlot == 1) colIndex = Constants.ColIndexEquipWepLeft2;
            else if (weaponEquipSlot == 2) colIndex = Constants.ColIndexEquipWepLeft3;
            else
            {
                throw new Exception($"Invalid equip slot {weaponEquipSlot}. Choose a value in [0, 1, 2]");
            }
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, colIndex, weaponId);
        }

        public void SetInitialEquipAmmunition(int charaInitId, int ammunitionEquipSlot, int ammunitionId, ushort ammunitionAmount)
        {
            int colIndexAmmunitionId, colIndexAmmunitionAmount;
            switch (ammunitionEquipSlot)
            {
                case 0:
                    {
                        colIndexAmmunitionId = Constants.ColIndexEquipArrow;
                        colIndexAmmunitionAmount = Constants.ColIndexEquipArrowAmount;
                        break;
                    }
                case 1:
                    {
                        colIndexAmmunitionId = Constants.ColIndexEquipSubArrow;
                        colIndexAmmunitionAmount = Constants.ColIndexEquipSubArrowAmount;
                        break;
                    }
                case 2:
                    {
                        colIndexAmmunitionId = Constants.ColIndexEquipBolt;
                        colIndexAmmunitionAmount = Constants.ColIndexEquipBoltAmount;
                        break;
                    }
                case 3:
                    {
                        colIndexAmmunitionId = Constants.ColIndexEquipSubBolt;
                        colIndexAmmunitionAmount = Constants.ColIndexEquipSubBoltAmount;
                        break;
                    }
                default:
                    {
                        throw new Exception($"Invalid equip slot {ammunitionEquipSlot}. Choose a value in [0, 1, 2, 3], corresponding to [arrow, subArrow, bolt, subBolt]");
                    }
            }
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, colIndexAmmunitionId, ammunitionId);
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, colIndexAmmunitionAmount, ammunitionAmount);
        }

        public void SetInitialEquipTalisman(int charaInitId, int itemSlot, int itemId)
        {
            if (itemSlot < 0 || itemSlot > 3)
            {
                throw new Exception($"Index {itemSlot} out of bounds.");
            }
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexEquipTalisman + itemSlot, itemId);
        }

        public void SetInitialEquipSpell(int charaInitId, int spellSlot, int spellId)
        {
            if (spellSlot < 0 || spellSlot > 6)
            {
                throw new Exception($"Index {spellSlot} out of bounds.");
            }
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexEquipSpell + spellSlot, spellId);
        }

        public void SetInitialEquipItem(int charaInitId, int itemSlot, int itemId)
        {
            if (itemSlot < 0 || itemSlot > 9)
            {
                throw new Exception($"Index {itemSlot} out of bounds.");
            }
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexItem + itemSlot, itemId);
        }

        public void SetInitialEquipItemAmount(int charaInitId, int itemSlot, byte itemAmount)
        {
            if (itemSlot < 0 || itemSlot > 9)
            {
                throw new Exception($"Index {itemSlot} out of bounds.");
            }
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexItemAmounts + itemSlot, itemAmount);
        }

        public void SetInitialMaxHpFlasks(int charaInitId, sbyte maxHpFlasks)
        {
            if (maxHpFlasks < 0 || maxHpFlasks > 20)
            {
                throw new Exception($"Index {maxHpFlasks} out of bounds.");
            }
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexMaxHpFlasks, maxHpFlasks);
        }

        public void SetInitialMaxFpFlasks(int charaInitId, sbyte maxFpFlasks)
        {
            if (maxFpFlasks < 0 || maxFpFlasks > 20)
            {
                throw new Exception($"Index {maxFpFlasks} out of bounds.");
            }
            SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, Constants.ColIndexMaxFpFlasks, maxFpFlasks);
        }
    }
}
