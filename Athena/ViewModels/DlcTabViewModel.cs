using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Athena.Commands;
using Athena.Services;

namespace Athena.ViewModels;

public class DlcTabViewModel : ModeTabViewModelBase, INotifyPropertyChanged
{
    private readonly DlcRandomizerService _randomizerService;
    private readonly EldenRingLauncherService _launcherService;

    public ICommand RandomizeCommand { get; }
    public ICommand LaunchCommand { get; }

    public DlcTabViewModel()
    {
        _randomizerService = new DlcRandomizerService();
        _launcherService = new EldenRingLauncherService();

        RandomizeCommand = new RelayCommand(() => _randomizerService.RandomizeDlc());
        LaunchCommand = new RelayCommand(() => _launcherService.LaunchEldenRing(LaunchMode.DLC));
    }

    // Add checkboxes and binding properties here if needed...

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
