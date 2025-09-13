using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using BrewScout.Models;

namespace BrewScout.ViewModels;

public partial class EventsListViewModel : ObservableObject
{
    [ObservableProperty] bool isBusy;
    [ObservableProperty] string query = "";
    [ObservableProperty] string categoryFilter = "All";
    [ObservableProperty] int rangeDays = 30;

    public List<string> Categories { get; set; } = new() { "All","Trivia","Live Music","Food Truck","Release","Festival","General" };
    public ObservableCollection<BrewEvent> Events { get; } = new();

    [RelayCommand]
    public async Task LoadAsync()
    {
        if (IsBusy) return; IsBusy = true;
        try
        {
            var list = await App.EventsDb.UpcomingAsync(RangeDays);
            if (CategoryFilter != "All") list = list.Where(e => e.Category == CategoryFilter).ToList();
            if (!string.IsNullOrWhiteSpace(Query)) list = list.Where(e =>
                (e.Title?.Contains(Query, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (e.City?.Contains(Query, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (e.Category?.Contains(Query, StringComparison.OrdinalIgnoreCase) ?? false)
            ).ToList();

            Events.Clear();
            foreach (var e in list) Events.Add(e);
        }
        finally { IsBusy = false; }
    }
}
