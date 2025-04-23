using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athena.Config;
using Athena.Core;

namespace Athena.Randomizer
{
    public partial class Randomizer
    {
        private void _randomizeBaseDlc()
        {
            _paramsEditor = ParamsEditor.ReadFromRegulationPath(Constants.RegulationInBaseDlc);
            _randomizePerfumeBottlesBaseDlc();
            _paramsEditor.WriteToRegulationPath(Constants.RegulationOutBaseDlc);
        }

        private void _randomizePerfumeBottlesBaseDlc()
        {
            if (_paramsEditor == null)
            {
                throw new Exception("Failed: _paramsEditor hasn't been initialized");
            }

            List<int> perfumeBottleLocationIDs = new List<int>()
        {
            16000110,   // Volcano manor
            31180000,   // Perfumer's Grotto
            1036510020, // Perfumer's Ruins (near Omenkiller)
            1039540040, // Shaded Castle
            1048380010  // Caelid
        };

            foreach (int itemLotId in perfumeBottleLocationIDs)
            {
                _paramsEditor.SetItemLotMapLotItemId(itemLotId, 0, 3520);
            }
        }
    }
}
