using BrewScout.Models;
using SQLite;

namespace BrewScout.Services;

public class EventsDb
{
    private readonly SQLiteAsyncConnection _db;
    public EventsDb(string dbPath) => _db = new SQLiteAsyncConnection(dbPath);

    public async Task InitAsync()
    {
        await _db.CreateTableAsync<BrewEvent>();
        if ((await _db.Table<BrewEvent>().CountAsync()) == 0)
        {
            await _db.InsertAsync(new BrewEvent {
                Title = "Trivia Night",
                Description = "General knowledge trivia. Prizes for top 3 teams.",
                StartLocal = DateTime.Today.AddDays(1).AddHours(19),
                EndLocal = DateTime.Today.AddDays(1).AddHours(21),
                VenueName = "Sunshine Brewing Co.",
                City = "Tampa", State = "FL", Category = "Trivia", IsFree = true
            });
        }
    }

    public Task<List<BrewEvent>> UpcomingAsync(int days = 30)
        => _db.Table<BrewEvent>()
              .Where(e => e.StartLocal >= DateTime.Now && e.StartLocal <= DateTime.Now.AddDays(days))
              .OrderBy(e => e.StartLocal).ToListAsync();

    public Task<int> SaveAsync(BrewEvent e) => e.Id == 0 ? _db.InsertAsync(e) : _db.UpdateAsync(e);
    public Task<int> DeleteAsync(BrewEvent e) => _db.DeleteAsync(e);
    public Task<BrewEvent?> GetAsync(int id) => _db.FindAsync<BrewEvent>(id);
}
