using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andre.Formats;
using Athena.Config;

namespace Athena.Core;

internal partial class ParamsEditor
{
    public const int ColIndexEquipId = 0;
    public const int ColIndexSellPrice = 1;
    public const int ColIndexMaterialId = 2;
    public const int ColIndexEventFlagForStock = 3;
    public const int ColIndexEventFlagForRelease = 4;
    public const int ColIndexSellQuantity = 5;
    public const int ColIndexEquipType = 7;
    public const int ColIndexCostType = 8;
    public const int ColIndexNumSold = 10;
    public const int ColIndexValueAdd = 11;
    public const int ColIndexValueMagnification = 12;
    public const int ColIndexIconId = 13;
    public const int ColIndexTextId = 14;
    public const int ColIndexMenuTextId = 15;
    public const int ColIndexMenuIconId = 16;

    public void CreateNewShopLineupRow(int shopLineupId, string? name = "")
    {
        // clone the first row. this is necessary because we can only add a row to the param if it has it as a parent
        Param.Row newRow = new(_shopLineup.Rows.ElementAt(0));
        newRow.ID = shopLineupId;
        newRow.Name = name;
        _idToRowIndexShopLineup.Add(shopLineupId, _shopLineup.Rows.Count);
        _shopLineup.AddRow(newRow);
        // Reset values to default (this row just has these three non-default values)
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEquipId, 0);
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEquipType, (byte)0);
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexSellPrice, 0);
    }

    public void SetShopLineupEquipId(int shopLineupId, int equipId)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEquipId, equipId);
    }

    public void SetShopLineupSellPrice(int shopLineupId, int sellPrice)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexSellPrice, sellPrice);
    }

    public void SetShopLineupMaterialId(int shopLineupId, int materialId)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexMaterialId, materialId);
    }

    public void SetShopLineupEventFlagForStock(int shopLineupId, uint eventFlag)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEventFlagForStock, eventFlag);
    }

    public void SetShopLineupEventFlagForRelease(int shopLineupId, uint eventFlag)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEventFlagForRelease, eventFlag);
    }

    public void SetShopLineupSellQuantity(int shopLineupId, short sellQuantity)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexSellQuantity, sellQuantity);
    }

    public void SetShopLineupEquipType(int shopLineupId, byte equipType)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexEquipType, equipType);
    }

    public void SetShopLineupCostType(int shopLineupId, byte costType)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexCostType, costType);
    }

    public void SetShopLineupNumSold(int shopLineupId, short numSold)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexNumSold, numSold);
    }

    public void SetShopLineupValueAdd(int shopLineupId, int valueAdd)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexValueAdd, valueAdd);
    }

    public void SetShopLineupValueMagnification(int shopLineupId, float valueMagnification)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexValueMagnification, valueMagnification);
    }

    public void SetShopLineupIconId(int shopLineupId, int iconId)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexIconId, iconId);
    }

    public void SetShopLineupTextId(int shopLineupId, int textId)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexTextId, textId);
    }

    public void SetShopLineupMenuTextId(int shopLineupId, int textId)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexMenuTextId, textId);
    }

    public void SetShopLineupMenuIconId(int shopLineupId, int iconId)
    {
        SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, ColIndexMenuIconId, iconId);
    }
}
