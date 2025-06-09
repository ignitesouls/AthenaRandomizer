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
        new BaseGameTabViewModel
        {
            Title = "Base Game", 
            Description = "Base Game" 
        },
        new BaseGameDlcTabViewModel 
        { 
            Title = "Base Game + DLC", 
            Description = "Base Game + DLC" 
        },
        new DlcTabViewModel 
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
        SelectedTab = ModeTabs[2];
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
