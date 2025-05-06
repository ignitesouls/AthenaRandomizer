using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SoulsFormats;
using System.Xml;
using System.Text.Json;

namespace Athena.Core
{
    /// <summary>
    /// The purpose of the ResourceManager is to load runtime-necessary data that is packaged
    /// within the bytecode of the executable. Furthermore, it loads the settings chosen by the
    /// user from local directories.
    /// </summary>
    internal class ResourceManager
    {
        /// <summary>
        /// ParamDef XML files are used by SoulsFormats to parse the data structures stored in 
        /// Elden Ring's Regulation.bin file. This is used to modify game data, such as the 
        /// items that are awarded at pickups.
        /// </summary>
        public static PARAMDEF GetParamDefByName(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using Stream? stream = assembly.GetManifestResourceStream($"Athena.Resources.ParamDefs.{resourceName}.xml");
            if (stream == null)
            {
                throw new Exception($"Failed to acquire ParamDef resource {resourceName} from assembly");
            }

            using StreamReader reader = new StreamReader(stream);
            string xmlContent = reader.ReadToEnd();
            XmlDocument xml = new();
            xml.LoadXml(xmlContent);
            return PARAMDEF.XmlSerializer.Deserialize(xml, false);
        }

        /// <summary>
        /// A mapping from weaponId -> itemLot locations. Used to do replacements wherever the weapon is found.
        /// </summary>
        public static Dictionary<int, List<int>> GetWeaponIDToItemLotIdsByName(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using Stream? stream = assembly.GetManifestResourceStream($"Athena.Resources.Metadata.{resourceName}.json");
            
            if (stream == null)
            {
                throw new Exception($"Failed to acquire Metadata resource {resourceName} from assembly");
            }

            using StreamReader reader = new StreamReader(stream);
            string json = reader.ReadToEnd();
            var metadata = JsonSerializer.Deserialize<Dictionary<int, List<int>>>(json);

            if (metadata == null)
            {
                throw new Exception($"Failed to parse JSON from resource: {resourceName}");
            }

            return metadata;
        }

        public static List<List<int>> GetWeaponGroupsFromSettingsFile(string settingsFile)
        {
            var list = new List<List<int>>();
            return list;
        }
    }
}
