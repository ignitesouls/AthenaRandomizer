using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athena.Config;

namespace Athena.Core
{
    internal partial class ParamsEditor
    {
        public object GetBaseScadutreeBlessingLevel()
        {
            return GetValueAtCell(_gameSystemCommon, null, 0, Constants.BaseScadutreeBlessingLevel);
        }

        public void SetBaseScadutreeBlessingLevel(int baseScadutreeBlessingLevel)
        {
            int value = Constants.DefaultScadutreeBlessingLevel + baseScadutreeBlessingLevel;
            SetValueAtCell(_gameSystemCommon, null, 0, Constants.BaseScadutreeBlessingLevel, value);
        }
    }
}
