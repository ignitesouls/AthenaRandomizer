using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Config;

public class AppConfig
{
    public int? LastUsedSeedDlc { get; set; }
    public int? LastRandomizedSeedDlc { get; set; }
    public int? LastUsedSeedBaseDlc { get; set; }
    public int? LastRandomizedSeedBaseDlc { get; set; }
    public int? LastUsedSeedBase { get; set; }
    public int? LastRandomizedSeedBase { get; set; }
}

