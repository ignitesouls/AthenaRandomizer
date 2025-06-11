using Athena.Commands;
using Athena.Config;
using Athena.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Athena.ViewModels;

public class DlcTabViewModel : ModeTabViewModelBase, INotifyPropertyChanged
{
    private readonly AppConfig _config;
    private readonly DlcRandomizerService _randomizerService;
    private readonly EldenRingLauncherService _launcherService;

    private int? _baseSeed;
    public int? BaseSeed
    {
        get => _baseSeed;
        set
        {
            if (_baseSeed != value)
            {
                _baseSeed = value;
                OnPropertyChanged();
            }
        }
    }

    private string? _baseSeedInput;
    public string? BaseSeedInput
    {
        get => _baseSeedInput;
        set
        {
            if (_baseSeedInput != value)
            {
                _baseSeedInput = value;
                OnPropertyChanged();
            }
        }
    }

    public int? ParsedBaseSeed =>
        int.TryParse(BaseSeedInput, out int parsed) ? parsed : null;
    
    public ICommand RandomizeCommand { get; }
    public ICommand LaunchCommand { get; }

    public DlcTabViewModel()
    {
        _config = ConfigService.Load();
        BaseSeedInput = _config.LastUsedSeed?.ToString();

        _randomizerService = new DlcRandomizerService();
        _launcherService = new EldenRingLauncherService();

        RandomizeCommand = new RelayCommand(() => _randomizerService.RandomizeDlc(
            ParsedBaseSeed,
            newSeed =>
            {
                BaseSeed = newSeed;
                BaseSeedInput = newSeed.ToString();
                _config.LastUsedSeed = newSeed;
                ConfigService.Save(_config);
            }
            ));
        LaunchCommand = new RelayCommand(() => _launcherService.LaunchEldenRing(LaunchMode.DLC));
    }

    // Add checkboxes and binding properties here if needed...

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
