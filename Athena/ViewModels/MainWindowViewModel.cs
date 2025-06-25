// SPDX-License-Identifier: GPL-3.0-only
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Athena.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public ObservableCollection<ModeTabViewModelBase> ModeTabs { get; } = new()
    {
        new TabViewModelBase
        {
            Title = "Base Game", 
            Description = "Base Game" 
        },
        new TabViewModelBaseDlc 
        { 
            Title = "Base Game + DLC", 
            Description = "Base Game + DLC" 
        },
        new TabViewModelDlc 
        { 
            Title = "DLC", 
            Description = "DLC" 
        }
    };

    private ModeTabViewModelBase _selectedTab;
    public ModeTabViewModelBase SelectedTab
    {
        get => _selectedTab;
        set
        {
            if (_selectedTab != value)
            {
                _selectedTab = value;
                OnPropertyChanged(nameof(SelectedTab));
            }
        }
    }

    public MainWindowViewModel()
    {
        // default tab
        _selectedTab = ModeTabs[0];
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
