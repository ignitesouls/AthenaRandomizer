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
    public object GetItemLotMapLotItemId(int itemLotId, int itemIndex)
    {
        if (itemIndex < 0 || itemIndex > 7)
        {
            throw new Exception($"Index {itemIndex} out of bounds.");
        }
        return GetValueAtCell(_itemLotMap, _idToRowIndexItemLotMap, itemLotId, ColIndexLotItemId + itemIndex);
    }

    public object GetItemLotMapCategory(int itemLotId, int itemIndex)
    {
        if (itemIndex < 0 || itemIndex > 7)
        {
            throw new Exception($"Index {itemIndex} out of bounds.");
        }
        return GetValueAtCell(_itemLotMap, _idToRowIndexItemLotMap, itemLotId, ColIndexCategory + itemIndex);
    }

    public void SetItemLotMapLotItemId(int itemLotId, int itemIndex, int itemId)
    {
        if (itemIndex < 0 || itemIndex > 7)
        {
            throw new Exception($"Index {itemIndex} out of bounds.");
        }
        SetValueAtCell(_itemLotMap, _idToRowIndexItemLotMap, itemLotId, ColIndexLotItemId + itemIndex, itemId);
    }

    public void SetItemLotMapCategory(int itemLotId, int itemIndex, int category)
    {
        if (itemIndex < 0 || itemIndex > 7)
        {
            throw new Exception($"Index {itemIndex} out of bounds.");
        }
        SetValueAtCell(_itemLotMap, _idToRowIndexItemLotMap, itemLotId, ColIndexCategory + itemIndex, category);
    }
}
