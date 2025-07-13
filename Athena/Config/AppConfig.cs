using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athena.Services;

namespace Athena.Config;

public class AppConfig
{
    // Global
    public string LastOpenedTabTitle { get; set; }

    // DLC
    public int? LastUsedSeedDlc { get; set; }
    public DlcMode? LastRandomizedModeDlc { get; set; }
    public int? LastRandomizedSeedDlc { get; set; }

    // Base DLC
    public int? LastUsedSeedBaseDlc { get; set; }
    public int? LastRandomizedSeedBaseDlc { get; set; }

    // Base
    public int? LastUsedSeedBase { get; set; }
    public int? LastRandomizedSeedBase { get; set; }
}

