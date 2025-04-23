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
        public const string RegulationInDlc = VanillaRegulation;
        public const string RegulationInBaseDlc = VanillaRegulation;
        
        public const string RegulationOutBase = $"{ModEngineWorkingDirectory}/base/regulation.bin";
        public const string RegulationOutDlc = $"{ModEngineWorkingDirectory}/dlc/regulation.bin";
        public const string RegulationOutBaseDlc = $"{ModEngineWorkingDirectory}/basedlc/regulation.bin";

        public const string MetadataWeaponIdToItemLotIdsMap = "./Resources/Metadata/WeaponIdToItemLotIdsMap.json";

        /**
         * Column Indices for params
         */
        // ItemLotParam
        public const int ColIndexLotItemId = 0;
        public const int ColIndexCategory = 8;

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
