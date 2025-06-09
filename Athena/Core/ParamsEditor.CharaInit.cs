using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athena.Config;

namespace Athena.Core;

internal partial class ParamsEditor
{
    public const int TotalStartingClasses = 10;
    public const int VagabondCharaInitId = 3000; // there's 10 total [3000, 3009]

    // runes
    public const int ColIndexRunesAmount = 3;
    // stats
    public const int ColIndexRuneLevel = 51;
    public const int ColIndexVigor = 52;
    public const int ColIndexMind = 53;
    public const int ColIndexEndurance = 54;
    public const int ColIndexStrength = 55;
    public const int ColIndexDexterity = 56;
    public const int ColIndexIntelligence = 57;
    public const int ColIndexFaith = 58;
    public const int ColIndexArcane = 59;
    // equipment - weapons
    public const int ColIndexEquipWepRight1 = 4;
    public const int ColIndexEquipWepRight2 = 5;
    public const int ColIndexEquipWepRight3 = 94;
    public const int ColIndexEquipWepLeft1 = 6;
    public const int ColIndexEquipWepLeft2 = 7;
    public const int ColIndexEquipWepLeft3 = 95;
    // these values are all 0 in vanilla regulation, probably just ignore them
    public const int ColIndexEquipWepTypeRight1 = 87;
    public const int ColIndexEquipWepTypeRight2 = 88;
    public const int ColIndexEquipWepTypeRight3 = 89;
    public const int ColIndexEquipWepTypeLeft1 = 90;
    public const int ColIndexEquipWepTypeLeft2 = 91;
    public const int ColIndexEquipWepTypeLeft3 = 92;
    // equipment - ammunition
    public const int ColIndexEquipArrow = 12;
    public const int ColIndexEquipArrowAmount = 46;
    public const int ColIndexEquipSubArrow = 14;
    public const int ColIndexEquipSubArrowAmount = 48;
    public const int ColIndexEquipBolt = 13;
    public const int ColIndexEquipBoltAmount = 47;
    public const int ColIndexEquipSubBolt = 15;
    public const int ColIndexEquipSubBoltAmount = 49;
    // equipment - armor
    public const int ColIndexEquipHelm = 8;
    public const int ColIndexEquipTorso = 9;
    public const int ColIndexEquipArm = 10;
    public const int ColIndexEquipLeg = 11;
    // equipment - talismans
    public const int ColIndexEquipTalisman = 16; // there's 4 total [16, 19]
    // equipment - spells
    public const int ColIndexEquipSpell = 24; // there's 7 total [24, 30]
    // items (EquipParamGoods)
    public const int ColIndexItem = 31; // there's 10 total [31, 40]
    public const int ColIndexItemAmounts = 62; // there's 10 total [62, 71]
    // hotbar items
    public const int ColIndexSecondaryItem = 97; // there's 6 total [97, 102]
    public const int ColIndexSecondaryItemAmounts = 103; // there's 6 total [103, 108]
    // maximum flasks (20 max, signed byte)
    public const int ColIndexMaxHpFlasks = 109;
    public const int ColIndexMaxFpFlasks = 110;

    // gestures
    public const int ColIndexGesture = 73; // there's 7 total [73, 79]

    public void SetInitialRunes(int charaInitId, int initialRunes)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexRunesAmount, initialRunes);
    }

    public void SetInitialRuneLevel(int charaInitId, Int16 initialRuneLevel)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexRuneLevel, initialRuneLevel);
    }

    public void SetInitialVigor(int charaInitId, byte startingVigor)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexVigor, startingVigor);
    }

    public void SetInitialMind(int charaInitId, byte startingMind)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexMind, startingMind);
    }

    public void SetInitialEndurance(int charaInitId, byte startingEndurance)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexEndurance, startingEndurance);
    }

    public void SetInitialStrength(int charaInitId, byte startingStrength)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexStrength, startingStrength);
    }

    public void SetInitialDexterity(int charaInitId, byte startingDexterity)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexDexterity, startingDexterity);
    }

    public void SetInitialIntelligence(int charaInitId, byte startingIntelligence)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexIntelligence, startingIntelligence);
    }

    public void SetInitialFaith(int charaInitId, byte startingFaith)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexFaith, startingFaith);
    }

    public void SetInitialArcane(int charaInitId, byte startingArcane)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexArcane, startingArcane);
    }

    public void SetInitialEquipHelm(int charaInitId, int helmId)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexEquipHelm, helmId);
    }

    public void SetInitialEquipTorso(int charaInitId, int torsoId)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexEquipTorso, torsoId);
    }

    public void SetInitialEquipArm(int charaInitId, int armId)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexEquipArm, armId);
    }

    public void SetInitialEquipLeg(int charaInitId, int legId)
    {
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexEquipLeg, legId);
    }

    public void SetInitialEquipWepRight(int charaInitId, int weaponEquipSlot, int weaponId)
    {
        int colIndex;
        if (weaponEquipSlot == 0) colIndex = ColIndexEquipWepRight1;
        else if (weaponEquipSlot == 1) colIndex = ColIndexEquipWepRight2;
        else if (weaponEquipSlot == 2) colIndex = ColIndexEquipWepRight3;
        else
        {
            throw new Exception($"Invalid equip slot {weaponEquipSlot}. Choose a value in [0, 1, 2]");
        }
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, colIndex, weaponId);
    }

    public void SetInitialEquipWepLeft(int charaInitId, int weaponEquipSlot, int weaponId)
    {
        int colIndex;
        if (weaponEquipSlot == 0) colIndex = ColIndexEquipWepLeft1;
        else if (weaponEquipSlot == 1) colIndex = ColIndexEquipWepLeft2;
        else if (weaponEquipSlot == 2) colIndex = ColIndexEquipWepLeft3;
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
                    colIndexAmmunitionId = ColIndexEquipArrow;
                    colIndexAmmunitionAmount = ColIndexEquipArrowAmount;
                    break;
                }
            case 1:
                {
                    colIndexAmmunitionId = ColIndexEquipSubArrow;
                    colIndexAmmunitionAmount = ColIndexEquipSubArrowAmount;
                    break;
                }
            case 2:
                {
                    colIndexAmmunitionId = ColIndexEquipBolt;
                    colIndexAmmunitionAmount = ColIndexEquipBoltAmount;
                    break;
                }
            case 3:
                {
                    colIndexAmmunitionId = ColIndexEquipSubBolt;
                    colIndexAmmunitionAmount = ColIndexEquipSubBoltAmount;
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
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexEquipTalisman + itemSlot, itemId);
    }

    public void SetInitialEquipSpell(int charaInitId, int spellSlot, int spellId)
    {
        if (spellSlot < 0 || spellSlot > 6)
        {
            throw new Exception($"Index {spellSlot} out of bounds.");
        }
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexEquipSpell + spellSlot, spellId);
    }

    public void SetInitialEquipItem(int charaInitId, int itemSlot, int itemId)
    {
        if (itemSlot < 0 || itemSlot > 9)
        {
            throw new Exception($"Index {itemSlot} out of bounds.");
        }
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexItem + itemSlot, itemId);
    }

    public void SetInitialEquipItemAmount(int charaInitId, int itemSlot, byte itemAmount)
    {
        if (itemSlot < 0 || itemSlot > 9)
        {
            throw new Exception($"Index {itemSlot} out of bounds.");
        }
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexItemAmounts + itemSlot, itemAmount);
    }

    public void SetInitialMaxHpFlasks(int charaInitId, sbyte maxHpFlasks)
    {
        if (maxHpFlasks < 0 || maxHpFlasks > 20)
        {
            throw new Exception($"Index {maxHpFlasks} out of bounds.");
        }
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexMaxHpFlasks, maxHpFlasks);
    }

    public void SetInitialMaxFpFlasks(int charaInitId, sbyte maxFpFlasks)
    {
        if (maxFpFlasks < 0 || maxFpFlasks > 20)
        {
            throw new Exception($"Index {maxFpFlasks} out of bounds.");
        }
        SetValueAtCell(_charaInit, _idToRowIndexCharaInit, charaInitId, ColIndexMaxFpFlasks, maxFpFlasks);
    }
}
