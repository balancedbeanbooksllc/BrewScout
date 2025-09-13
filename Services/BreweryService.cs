using System.Text.Json;
using BrewScout.Models;

namespace BrewScout.Services;

public class BreweryService
{
    public async Task<List<Brewery>> GetBreweriesAsync()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("Data/breweries.sample.json");
        using var sr = new StreamReader(stream);
        var json = await sr.ReadToEndAsync();
        return JsonSerializer.Deserialize<List<Brewery>>(json) ?? new();
    }
}
