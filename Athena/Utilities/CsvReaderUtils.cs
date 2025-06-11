// SPDX-License-Identifier: GPL-3.0-only
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using CsvHelper;
using Athena.Config;

namespace Athena.Utilities;

public class ShopItem
{
    public required string Name { get; set; }
    public required string Type { get; set; }
    public int Cost { get; set; }
    public required string ParamType { get; set; }
    public byte EquipType { get; set; }
    public int ID { get; set; }
    public uint? EventFlagID { get; set; }
    public short SellQuantity { get; set; }
}

public class WeaponGroup
{
    public required string WeaponClass { get; set; }
    public required string Name { get; set; }
    public bool IsRemembrance { get; set; }
    public bool IsSomber { get; set; }
    public int WeaponID { get; set; }
}

public class ArmorSet
{
    public required string Name { get; set; }
    public int? HelmID { get; set; }
    public int? TorsoID { get; set; }
    public int? GauntletsID { get; set; }
    public int? GreavesID { get; set; }
}

public class Weapon
{
    public required string Name { get; set; }
    public int WeaponID { get; set; }
}

public class CustomWeapon
{
    public required string Name { get; set; }
    public int WeaponID { get; set; }
    public int GemID { get; set; }
    public byte ReinforceLevel { get; set; }
}

public class CsvReaderUtils
{
    public static List<T> Read<T>(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<T>().ToList();
        return records;
    }

    public static Dictionary<int, Weapon> GetAllWeapons()
    {
        List<Weapon> weaponsRows = Read<Weapon>($"{Constants.GameData}/AllWeapons.csv");
        Dictionary<int, Weapon> weaponsDict = new();
        foreach ( Weapon weapon in weaponsRows )
        {
            weaponsDict.Add(weapon.WeaponID, weapon);
        }
        return weaponsDict;
    }

    public static Dictionary<int, CustomWeapon> GetAllCustomWeapons()
    {
        List<CustomWeapon> customWeaponsRows = Read<CustomWeapon>($"{Constants.GameData}/AllCustomWeapons.csv");
        Dictionary<int, CustomWeapon> customWeaponsDict = new();
        foreach (CustomWeapon weapon in customWeaponsRows)
        {
            customWeaponsDict.Add(weapon.WeaponID, weapon);
        }
        return customWeaponsDict;
    }
}
