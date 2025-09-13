using BrewScout.Models;
using SQLite;

namespace BrewScout.Services;

public class NotesDb
{
    private readonly SQLiteAsyncConnection _db;
    public NotesDb(string dbPath) => _db = new SQLiteAsyncConnection(dbPath);

    public async Task InitAsync()
    {
        await _db.CreateTableAsync<BeerNote>();
    }

    public Task<List<BeerNote>> GetAllAsync() => _db.Table<BeerNote>().OrderByDescending(n=>n.CreatedUtc).ToListAsync();
    public Task<int> SaveAsync(BeerNote note) => _db.InsertAsync(note);
    public Task<int> DeleteAsync(BeerNote note) => _db.DeleteAsync(note);
}
