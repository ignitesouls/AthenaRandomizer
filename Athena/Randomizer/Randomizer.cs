using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athena.Core;
using Athena.Config;
using System.Printing;
using System.Text.Json;

namespace Athena.Randomizer;

public partial class Randomizer
{
    private string _mode;

    private List<List<int>> _weaponGroups;
    private Dictionary<int, List<int>> _weaponIdToItemLotIdsMap;
    //private Dictionary<int, List<int>> _weaponIdToItemLotIdsEnemy;

    private ParamsEditor? _paramsEditor;
    private SeedManager? _seedManager;

    public Randomizer(string mode)
    {
        if (mode != Constants.OptionBase && mode != Constants.OptionDlc && mode != Constants.OptionBaseDlc)
        {
            throw new ArgumentException($"Invalid mode: {mode}");
        }
        _mode = mode;
        _weaponGroups = _readWeaponGroups();
        _weaponIdToItemLotIdsMap = ResourceManager.GetWeaponIDToItemLotIdsByName("WeaponIdToItemLotIdsMap");
        Dictionary<int, List<int>>.KeyCollection keys = _weaponIdToItemLotIdsMap.Keys;
        for (int i = 0; i < keys.Count; i++)
        {
            Debug.WriteLine($"key {i}: {keys.ElementAt(i)}");
            List<int> itemLotIds = _weaponIdToItemLotIdsMap[keys.ElementAt(i)];
            for (int j = 0; j < itemLotIds.Count; j++)
            {
                Debug.WriteLine($"element {j}: {itemLotIds[j]}");
            }
        }

        _seedManager = new SeedManager();
        Debug.WriteLine($"{_seedManager.GetBaseSeed()}");
    }

    private List<List<int>> _readWeaponGroups()
    {
        return new List<List<int>>();
    }

    public void run()
    {
        switch (_mode) {
            case Constants.OptionBase:
                {
                    _randomizeBase();
                    break;
                }
            case Constants.OptionBaseDlc:
                {
                    _randomizeBaseDlc();
                    break;
                }
            case Constants.OptionDlc:
                {
                    _randomizeDlc();
                    break;
                }
        }
    }
}
