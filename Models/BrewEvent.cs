using SQLite;

namespace BrewScout.Models;

public class BrewEvent
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime StartLocal { get; set; }
    public DateTime? EndLocal { get; set; }
    public string? BreweryId { get; set; }
    public string VenueName { get; set; } = "";
    public string Street { get; set; } = "";
    public string City { get; set; } = "";
    public string State { get; set; } = "";
    public string Country { get; set; } = "USA";
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string Category { get; set; } = "General";
    public bool IsAllDay { get; set; } = false;
    public bool IsFree { get; set; } = true;
    public string InfoUrl { get; set; } = "";
    public string TicketUrl { get; set; } = "";
}
