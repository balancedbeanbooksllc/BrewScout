using Microsoft.Maui.Controls.Maps;
using BrewScout.Services;

namespace BrewScout.Views;

public partial class MapPage : ContentPage
{
    public MapPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var svc = new BreweryService();
        var breweries = await svc.GetBreweriesAsync();
        Map.Pins.Clear();
        foreach (var b in breweries.Where(b=>b.Latitude.HasValue && b.Longitude.HasValue))
        {
            Map.Pins.Add(new Pin
            {
                Label = b.Name,
                Address = b.City,
                Location = new Location(b.Latitude!.Value, b.Longitude!.Value)
            });
        }
    }
}
