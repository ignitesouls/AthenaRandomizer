using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Config
{
    internal class Constants
    {
        // File or Directory Locations
        public const string VanillaRegulation = "./Resources/Vanilla/regulation.bin";
        public const string ModEngineWorkingDirectory = "./Resources/ModEngine-2.1.0.0-win64";
        
        public const string LaunchEldenRingBase = "launchmod_base.bat";
        public const string LaunchEldenRingDlc = "launchmod_dlc.bat";
        public const string LaunchEldenRingBaseDlc = "launchmod_basedlc.bat";
        
        public const string RegulationInBase = VanillaRegulation;
        public const string RegulationInDlc = $"{ModEngineWorkingDirectory}/dlc/regulation.bin";
        public const string RegulationInBaseDlc = VanillaRegulation;
        
        public const string RegulationOutBase = $"{ModEngineWorkingDirectory}/base/regulation.bin";
        public const string RegulationOutDlc = $"{ModEngineWorkingDirectory}/dlc/regulation.bin";
        public const string RegulationOutBaseDlc = $"{ModEngineWorkingDirectory}/basedlc/regulation.bin";

        public const string MetadataWeaponIdToItemLotIdsMap = "./Resources/Metadata/WeaponIdToItemLotIdsMap.json";

        /**
         * Weapon/Items/Goods/Talismans Constants
         */
        public const int ClubItemId = 11010000;

        /**
         * Column Indices for params
         */
        // CharaInitParam
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

        // ItemLotParam
        public const int ColIndexLotItemId = 0; // there's 8 total [0, 7]
        public const int ColIndexCategory = 8;  // there's 8 total [8, 15]

        // ShopLineupParam
        public const int TextId = 14;

        // GameSystemCommonParam
        public const int DefaultScadutreeBlessingLevel = 20000100;
        public const int BaseScadutreeBlessingLevel = 331;
        public const int BaseReveredSpiritAshLevel = 332;

        // Params constants for reading/writing to regulation.bin
        public const string ItemLotParam_map = "ItemLotParam_map.param";
        public const string ItemLotParam_enemy = "ItemLotParam_enemy.param";
        public const string ItemLotParamDef = "ItemLotParam";
        
        public const string ShopLineupParam = "ShopLineupParam.param";
        public const string ShopLineupParamDef = "ShopLineupParam";
        
        public const string CharaInitParam = "CharaInitParam.param";
        public const string CharaInitParamDef = "CharaInitParam";
        
        public const string GameSystemCommonParam = "GameSystemCommonParam.param";
        public const string GameSystemCommonParamDef = "GameSystemCommonParam";

        // Randomizer options
        public const string OptionBase = "base";
        public const string OptionDlc = "dlc";
        public const string OptionBaseDlc = "basedlc";
    }
}
