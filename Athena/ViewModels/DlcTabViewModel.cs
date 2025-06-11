using Athena.Commands;
using Athena.Config;
using Athena.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

    private int? _randomizedSeed;
    public int? RandomizedSeed
    {
        get => _randomizedSeed;
        set
        {
            if (_randomizedSeed != value)
            {
                _randomizedSeed = value;
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
                BaseSeed = int.TryParse(BaseSeedInput, out int parsed) ? parsed : null;
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
        BaseSeed = _config.LastUsedSeed;
        BaseSeedInput = _config.LastUsedSeed?.ToString();
        RandomizedSeed = _config.LastRandomizedSeed;

        _randomizerService = new DlcRandomizerService();
        _launcherService = new EldenRingLauncherService();

        RandomizeCommand = new RelayCommand(() => _randomizerService.RandomizeDlc(
            ParsedBaseSeed,
            newSeed =>
            {
                Debug.WriteLine($"baseSeed: {newSeed}");
                BaseSeed = newSeed;
                BaseSeedInput = newSeed.ToString();
                _config.LastUsedSeed = newSeed;
                ConfigService.Save(_config);
            },
            newRandomizedSeed =>
            {
                Debug.WriteLine($"randomizedSeed: {newRandomizedSeed}");
                RandomizedSeed = newRandomizedSeed;
                _config.LastRandomizedSeed = newRandomizedSeed;
                ConfigService.Save(_config);
            }));
        LaunchCommand = new RelayCommand(
            () => _launcherService.LaunchEldenRing(LaunchMode.DLC),
            () => (BaseSeed == RandomizedSeed) && (BaseSeed != null));
    }

    // Add checkboxes and binding properties here if needed...

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
