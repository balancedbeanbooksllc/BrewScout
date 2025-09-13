using BrewScout.Services;

namespace BrewScout;

public partial class App : Application
{
    public static NotesDb NotesDb { get; private set; } = default!;
    public static EventsDb EventsDb { get; private set; } = default!;

    public App()
    {
        InitializeComponent();

        var notesPath = Path.Combine(FileSystem.AppDataDirectory, "notes.db3");
        var eventsPath = Path.Combine(FileSystem.AppDataDirectory, "events.db3");
        NotesDb = new NotesDb(notesPath);
        EventsDb = new EventsDb(eventsPath);

        MainPage = new AppShell();
    }

    protected override async void OnStart()
    {
        await NotesDb.InitAsync();
        await EventsDb.InitAsync();
        base.OnStart();
    }
}
