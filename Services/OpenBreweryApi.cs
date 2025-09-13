using System.Text.Json;
using BrewScout.Models;

namespace BrewScout.Services;

public class OpenBreweryApi
{
    static readonly HttpClient _http = new();
    const string Base = "https://api.openbrewerydb.org/v1/breweries?per_page=20&by_country=United%20States";

    public async Task<List<Brewery>> FetchAsync()
    {
        var json = await _http.GetStringAsync(Base);
        // Map or adapt as needed
        var list = JsonSerializer.Deserialize<List<Brewery>>(json) ?? new();
        return list;
    }
}
