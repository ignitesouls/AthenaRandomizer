// SPDX-License-Identifier: GPL-3.0-only
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Athena.ViewModels;

public abstract class ModeTabViewModelBase
{
    public string Title { get; set; }
    public string Description { get; set; }
}

