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
    internal class Resources
    {
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
    }
}
