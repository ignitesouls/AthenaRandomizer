// SPDX-License-Identifier: GPL-3.0-only
using System.IO;

namespace Athena.Config;

internal class Constants
{
    // Mod Configuration
    public static string ModEngineWorkingDirectory = Path.Combine("Resources", "ModEngine-2.1.0.0-win64");
    public static string RegulationBase = Path.Combine("Resources", "Regulation");
    
    public static string VanillaRegulation = Path.Combine(RegulationBase, "vanilla", "regulation.bin");
    public static string RegulationInBase = VanillaRegulation;
    public static string RegulationInBaseDlc = VanillaRegulation;
    public static string RegulationInDlc = Path.Combine(RegulationBase, "dlc", "regulation.bin");
    //public static string RegulationInDlc = Path.Combine(ModEngineWorkingDirectory, "dlc", "regulation.bin");

    public static string RegulationOutBase = Path.Combine(ModEngineWorkingDirectory, "base", "regulation.bin");
    public static string RegulationOutBaseDlc = Path.Combine(ModEngineWorkingDirectory, "basedlc", "regulation.bin");
    public static string RegulationOutDlc = Path.Combine(ModEngineWorkingDirectory, "dlc", "regulation.bin");
    
    public static string MapFolderDlc = Path.Combine(ModEngineWorkingDirectory, "dlc", "map", "MapStudio");

    // Launch Configuration
    public static string LaunchEldenRingBase = "launchmod_base.bat";
    public static string LaunchEldenRingBaseDlc = "launchmod_basedlc.bat";
    public static string LaunchEldenRingDlc = "launchmod_dlc.bat";
    
    // Metadata
    public static string RandomizationGroups = Path.Combine("Resources", "RandomizationGroups");
    public static string RandomizationGroupsBase = Path.Combine(RandomizationGroups, "base");
    public static string RandomizationGroupsBaseDlc = Path.Combine(RandomizationGroups, "basedlc");
    public static string RandomizationGroupsDlc = Path.Combine(RandomizationGroups, "dlc");

    public static string GameData = Path.Combine("Resources", "GameData");

    public static string Misc = Path.Combine("Resources", "Misc");
}
