// SPDX-License-Identifier: GPL-3.0-only
using Athena.Config;
using Athena.Properties;

namespace Athena.Services;

public static class ConfigService
{
    private static readonly Lazy<AppConfig> Current = new(ReadSettings);

    public static AppConfig Load()
    {
        return Current.Value;
    }

    private static AppConfig ReadSettings()
    {
        return new AppConfig
        {
            LastOpenedTabTitle = NullIfEmpty(Settings.Default.LastOpenedTabTitle),
            LastUsedSeedDlc = ParseNullableInt(Settings.Default.LastUsedSeedDlc),
            LastRandomizedModeDlc = ParseNullableEnum<DlcMode>(Settings.Default.LastRandomizedModeDlc),
            LastRandomizedSeedDlc = ParseNullableInt(Settings.Default.LastRandomizedSeedDlc),
            LastUsedSeedBaseDlc = ParseNullableInt(Settings.Default.LastUsedSeedBaseDlc),
            LastRandomizedSeedBaseDlc = ParseNullableInt(Settings.Default.LastRandomizedSeedBaseDlc),
            LastRandomizedModeBaseDlc = ParseNullableEnum<BaseDlcMode>(Settings.Default.LastRandomizedModeBaseDlc),
            LastUsedSeedBase = ParseNullableInt(Settings.Default.LastUsedSeedBase),
            LastRandomizedSeedBase = ParseNullableInt(Settings.Default.LastRandomizedSeedBase),
            LastRandomizedModeBase = ParseNullableEnum<BaseMode>(Settings.Default.LastRandomizedModeBase)
        };
    }

    public static void Save(AppConfig config)
    {
        Settings.Default.LastOpenedTabTitle = config.LastOpenedTabTitle ?? string.Empty;
        Settings.Default.LastUsedSeedDlc = Format(config.LastUsedSeedDlc);
        Settings.Default.LastRandomizedModeDlc = Format(config.LastRandomizedModeDlc);
        Settings.Default.LastRandomizedSeedDlc = Format(config.LastRandomizedSeedDlc);
        Settings.Default.LastUsedSeedBaseDlc = Format(config.LastUsedSeedBaseDlc);
        Settings.Default.LastRandomizedSeedBaseDlc = Format(config.LastRandomizedSeedBaseDlc);
        Settings.Default.LastRandomizedModeBaseDlc = Format(config.LastRandomizedModeBaseDlc);
        Settings.Default.LastUsedSeedBase = Format(config.LastUsedSeedBase);
        Settings.Default.LastRandomizedSeedBase = Format(config.LastRandomizedSeedBase);
        Settings.Default.LastRandomizedModeBase = Format(config.LastRandomizedModeBase);
        Settings.Default.Save();
    }

    private static string? NullIfEmpty(string value) =>
        string.IsNullOrWhiteSpace(value) ? null : value;

    private static int? ParseNullableInt(string value) =>
        int.TryParse(value, out int parsed) ? parsed : null;

    private static TEnum? ParseNullableEnum<TEnum>(string value) where TEnum : struct, Enum =>
        Enum.TryParse(value, out TEnum parsed) ? parsed : null;

    private static string Format<T>(T? value) where T : struct =>
        value?.ToString() ?? string.Empty;
}
