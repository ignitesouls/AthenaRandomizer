// SPDX-License-Identifier: GPL-3.0-only
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
        BaseSeed = _config.LastUsedSeedDlc;
        BaseSeedInput = _config.LastUsedSeedDlc?.ToString();
        RandomizedSeed = _config.LastRandomizedSeedDlc;

        _randomizerService = new DlcRandomizerService();
        _launcherService = new EldenRingLauncherService();

        RandomizeCommand = new RelayCommand(() => _randomizerService.RandomizeDlc(
            ParsedBaseSeed,
            newSeed =>
            {
                Debug.WriteLine($"baseSeed: {newSeed}");
                BaseSeed = newSeed;
                BaseSeedInput = newSeed.ToString();
                _config.LastUsedSeedDlc = newSeed;
                ConfigService.Save(_config);
            },
            newRandomizedSeed =>
            {
                Debug.WriteLine($"randomizedSeed: {newRandomizedSeed}");
                RandomizedSeed = newRandomizedSeed;
                _config.LastRandomizedSeedDlc = newRandomizedSeed;
                ConfigService.Save(_config);
            }),
            () => !((BaseSeed == RandomizedSeed) && (BaseSeed != null)));

        LaunchCommand = new RelayCommand(
            () => _launcherService.LaunchEldenRing(LaunchMode.DLC),
            () => (BaseSeed == RandomizedSeed) && (BaseSeed != null));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
