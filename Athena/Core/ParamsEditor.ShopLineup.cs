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
        public void SetShopLineupTextId(int shopLineupId, int textId)
        {
            SetValueAtCell(_shopLineup, _idToRowIndexShopLineup, shopLineupId, Constants.TextId, textId);
        }
    }
}
