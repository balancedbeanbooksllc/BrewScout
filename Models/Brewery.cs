namespace BrewScout.Models;

public class Brewery
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = "";
    public string City { get; set; } = "";
    public string State { get; set; } = "";
    public string Country { get; set; } = "";
    public string Street { get; set; } = "";
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string Phone { get; set; } = "";
    public string WebsiteUrl { get; set; } = "";
}
