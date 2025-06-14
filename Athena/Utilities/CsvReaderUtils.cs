// SPDX-License-Identifier: GPL-3.0-only
using System.Globalization;
using System.IO;
using CsvHelper;

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
}
