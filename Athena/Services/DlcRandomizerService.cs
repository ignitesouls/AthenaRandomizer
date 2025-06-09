using Athena.Config;
using Athena.Core;
using CsvHelper;
using System.Globalization;
using System.IO;
using UniversalReplacementRandomizer;

namespace Athena.Services;

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

public class DlcRandomizerService
{
    public void RandomizeDlc()
    {

        var urr = new UniversalReplacementRandomizer.UniversalReplacementRandomizer();

        var group = new UniversalReplacementRandomizer.RandomizationGroup(new(), new());

        urr.AddGroup("check", group);

        var editor = ParamsEditor.ReadFromRegulationPath(Constants.RegulationInDlc);

        InitDlcShop(editor);
        InitStartingClasses(editor);

        // InitMillicentMerchant(editor); // I THINK I'M GONNA DO THIS ( I am not gonna do this )

        editor.WriteToRegulationPath(Constants.RegulationOutDlc);
    }

    private List<ShopItem> ReadItemsCsv(string fileName)
    {
        string filePath = $".\\Resources\\Metadata\\{fileName}";
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<ShopItem>().ToList();
        return records;
    }

    private void InitDlcShop(ParamsEditor editor)
    {
        // the starlight shop will have random weapons available at the start of the match.
        // also, there is some degree of customization, since we dynamically build the inventory from
        // JSON file(s).

        // read in the list of shop items
        List<ShopItem> shopItems = ReadItemsCsv("ShopItems.csv");

        // POTENTIAL SCALING SITUATION: might have to update the blah blah here, for reasons:
        // Event flags are stored permanently if the thousands place is one of the following digits: 0, 4, 7, 8, 9
        // starting with 1056447000 gives us 400 items before we reach an invalid ID: 1056447000, 1056448000, 1056449000, 1056450000

        //List<uint> startingEventFlagIDs = new List<uint>
        //{
        //    1056440000, 1056444000, 1056447000, 1056448000, 1056449000
        //};
        // int currentEventFlagIDsIndex = 0;

        int currentShopLineupId = 9100000;
        uint currentEventFlagID = 1056447000;
        uint eventFlagStepSize = 10;
        for (int i = 0; i < shopItems.Count; i++)
        {
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - {shopItems[i].Type}] {shopItems[i].Name}";
            int equipID = shopItems[i].ID;
            byte equipType = shopItems[i].EquipType;
            int sellPrice = shopItems[i].Cost;
            short sellQuantity = shopItems[i].SellQuantity;
            uint eventFlagForQuantity;
            if (shopItems[i].EventFlagID == null)
            {
                eventFlagForQuantity = currentEventFlagID;
                currentEventFlagID += eventFlagStepSize;
            }
            else
            {
                eventFlagForQuantity = (uint)shopItems[i].EventFlagID!;
            }
            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipType);
            editor.SetShopLineupSellPrice(shopLineupId, sellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, sellQuantity);
        }

        // Now, set up fixed portion of the starlight shop.
        List<string> ignoreTypes = new List<string> { "Whetblade", "Upgrade Stone", "Ash of War" };
        currentShopLineupId = 9200000;
        currentEventFlagID = 1056457000;
        for (int i = 0; i < shopItems.Count; i++)
        {
            string itemType = shopItems[i].Type;
            if (ignoreTypes.Contains(itemType))
                continue;
            int shopLineupId = currentShopLineupId++;
            string name = $"[Merchant Millicent - Starlight Shop - {shopItems[i].Type}] {shopItems[i].Name}";
            int equipID = shopItems[i].ID;
            byte equipType = shopItems[i].EquipType;
            byte starlightShardCostType = 2;
            short sellQuantity = shopItems[i].SellQuantity;
            uint eventFlagForQuantity;
            if (shopItems[i].EventFlagID == null)
            {
                eventFlagForQuantity = currentEventFlagID;
                currentEventFlagID += eventFlagStepSize;
            }
            else
            {
                eventFlagForQuantity = (uint)shopItems[i].EventFlagID!;
            }

            int sellPrice = 1;
            if (shopItems[i].Type == "Talisman")
            {
                int cost = shopItems[i].Cost;
                if (cost > 40000)
                {
                    sellPrice = 3;
                }
                else if (cost > 20000)
                {
                    sellPrice = 2;
                }
            }

            editor.CreateNewShopLineupRow(shopLineupId, name);
            editor.SetShopLineupEquipId(shopLineupId, equipID);
            editor.SetShopLineupEquipType(shopLineupId, equipType);
            editor.SetShopLineupCostType(shopLineupId, starlightShardCostType);
            editor.SetShopLineupSellPrice(shopLineupId, sellPrice);
            editor.SetShopLineupEventFlagForStock(shopLineupId, eventFlagForQuantity);
            editor.SetShopLineupSellQuantity(shopLineupId, sellQuantity);
        }
    }

    private void InitStartingClasses(ParamsEditor editor)
    {
        int NumberOfStartingRunes = 100000;

        int ClubItemId = 11010000;
        int GlintstoneStaffItemId = 33000025;
        int FingerSealItemId = 34000025;
        for (int i = 0; i < ParamsEditor.TotalStartingClasses; i++)
        {
            int charaInitId = ParamsEditor.VagabondCharaInitId + i;
            // reset all stats
            editor.SetInitialRuneLevel(charaInitId, 1);
            editor.SetInitialVigor(charaInitId, 50);
            editor.SetInitialMind(charaInitId, 10);
            editor.SetInitialEndurance(charaInitId, 10);
            editor.SetInitialStrength(charaInitId, 10);
            editor.SetInitialDexterity(charaInitId, 10);
            editor.SetInitialIntelligence(charaInitId, 10);
            editor.SetInitialFaith(charaInitId, 10);
            editor.SetInitialArcane(charaInitId, 10);

            // initial runes and flasks
            editor.SetInitialRunes(charaInitId, NumberOfStartingRunes);
            editor.SetInitialMaxHpFlasks(charaInitId, 12);
            editor.SetInitialMaxFpFlasks(charaInitId, 2);

            // clear all initial equipment
            for (int j = 0; j < 2; j++)
            {
                editor.SetInitialEquipWepRight(charaInitId, j, -1);
                editor.SetInitialEquipWepLeft(charaInitId, j, -1);
            }
            for (int j = 0; j < 4; j++)
            {
                editor.SetInitialEquipAmmunition(charaInitId, j, -1, 0);
            }
            for (int j = 0; j < 7; j++)
            {
                editor.SetInitialEquipSpell(charaInitId, j, -1);
            }
            editor.SetInitialEquipHelm(charaInitId, -1);
            editor.SetInitialEquipTorso(charaInitId, -1);
            editor.SetInitialEquipArm(charaInitId, -1);
            editor.SetInitialEquipLeg(charaInitId, -1);

            // clear all items
            for (int j = 0; j < 10; j++)
            {
                editor.SetInitialEquipItem(charaInitId, j, -1);
                editor.SetInitialEquipItemAmount(charaInitId, j, 0);
            }

            // give initial weapons (club +0, staff +25, seal +25)
            editor.SetInitialEquipWepRight(charaInitId, 0, ClubItemId);
            editor.SetInitialEquipWepLeft(charaInitId, 0, GlintstoneStaffItemId);
            editor.SetInitialEquipWepLeft(charaInitId, 1, FingerSealItemId);

            // give starlight shards
            editor.SetInitialEquipItem(charaInitId, 9, 1290);
            editor.SetInitialEquipItemAmount(charaInitId, 9, 10);
        }
    }
}
