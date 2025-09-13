using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using BrewScout.Models;
using BrewScout.Services;

namespace BrewScout.ViewModels;

public partial class BreweryListViewModel : ObservableObject
{
    private readonly BreweryService _service;
    public ObservableCollection<Brewery> Breweries { get; } = new();

    [ObservableProperty] bool isBusy;
    [ObservableProperty] string search = "";

    public BreweryListViewModel(BreweryService service) => _service = service;

    [RelayCommand]
    public async Task LoadAsync()
    {
        if (IsBusy) return; IsBusy = true;
        try
        {
            var items = await _service.GetBreweriesAsync();
            var filtered = string.IsNullOrWhiteSpace(Search) ? items :
                items.Where(b => (b.Name ?? "").Contains(Search, StringComparison.OrdinalIgnoreCase) ||
                                 (b.City ?? "").Contains(Search, StringComparison.OrdinalIgnoreCase)).ToList();
            Breweries.Clear();
            foreach (var b in filtered) Breweries.Add(b);
        }
        finally { IsBusy = false; }
    }
}
