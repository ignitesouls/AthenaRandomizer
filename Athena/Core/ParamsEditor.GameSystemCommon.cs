using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athena.Config;

namespace Athena.Core;

internal partial class ParamsEditor
{
    public const int DefaultScadutreeBlessingLevel = 20000100;
    public const int BaseScadutreeBlessingLevel = 331;
    public const int BaseReveredSpiritAshLevel = 332;

    public object GetBaseScadutreeBlessingLevel()
    {
        return GetValueAtCell(_gameSystemCommon, null, 0, BaseScadutreeBlessingLevel);
    }

    public void SetBaseScadutreeBlessingLevel(int baseScadutreeBlessingLevel)
    {
        int value = DefaultScadutreeBlessingLevel + baseScadutreeBlessingLevel;
        SetValueAtCell(_gameSystemCommon, null, 0, BaseScadutreeBlessingLevel, value);
    }
}
