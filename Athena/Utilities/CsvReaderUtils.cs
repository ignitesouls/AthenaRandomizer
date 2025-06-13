// SPDX-License-Identifier: GPL-3.0-only
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using CsvHelper;
using Athena.Config;
using Athena.Models;

namespace Athena.Utilities;

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
