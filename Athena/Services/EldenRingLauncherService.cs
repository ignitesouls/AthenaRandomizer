using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athena.Config;

namespace Athena.Services;

public enum LaunchMode
{
    Base,
    BaseDlc,
    DLC
}

public class EldenRingLauncherService
{
    public void LaunchEldenRing(LaunchMode mode)
    {
        string fileName = mode switch
        {
            LaunchMode.Base => Constants.LaunchEldenRingBase,
            LaunchMode.BaseDlc => Constants.LaunchEldenRingBaseDlc,
            LaunchMode.DLC => Constants.LaunchEldenRingDlc,
            _ => throw new ArgumentOutOfRangeException()
        };

        Process.Start(new ProcessStartInfo
        {
            FileName = fileName,
            WorkingDirectory = Constants.ModEngineWorkingDirectory,
            UseShellExecute = true,
            CreateNoWindow = true
        });
    }
}
