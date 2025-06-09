using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Config;

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

    public const string MapFolderDlc = $"{ModEngineWorkingDirectory}/dlc/map/MapStudio";

    public const string MetadataWeaponIdToItemLotIdsMap = "./Resources/Metadata/WeaponIdToItemLotIdsMap.json";
}
