// SPDX-License-Identifier: GPL-3.0-only
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using Athena.Config;

namespace Athena.Services;

public static class ConfigService
{
    private static readonly string ConfigPath = Path.Combine(Constants.Misc, "appconfig.json");

    public static AppConfig Load()
    {
        if (!File.Exists(ConfigPath))
            return new AppConfig();

        string json = File.ReadAllText(ConfigPath);
        return JsonSerializer.Deserialize<AppConfig>(json) ?? new AppConfig();
    }

    public static void Save(AppConfig config)
    {
        string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(ConfigPath, json);
    }
}
