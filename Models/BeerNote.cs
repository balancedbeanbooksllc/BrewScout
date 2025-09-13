using SQLite;

namespace BrewScout.Models;

public class BeerNote
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public string BeerName { get; set; } = "";
    public string Style { get; set; } = "";
    public int Rating { get; set; } // 1-5
    public string Notes { get; set; } = "";
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    public string? BreweryId { get; set; }
}
