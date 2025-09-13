using System.Text;
using BrewScout.Models;

namespace BrewScout.Views;

[QueryProperty(nameof(Id), "id")]
public partial class EventDetailPage : ContentPage
{
    public int Id { get; set; }
    BrewEvent _model = new();

    public EventDetailPage() => InitializeComponent();

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _model = await App.EventsDb.GetAsync(Id) ?? new BrewEvent();
        TitleLabel.Text = _model.Title;
        TimeLabel.Text = _model.StartLocal.ToString("dddd, MMM d h:mm tt");
        VenueLabel.Text = _model.VenueName;
        CityLabel.Text = $"{_model.City}, {_model.State}";
        DescLabel.Text = _model.Description;
        InfoBtn.IsVisible = !string.IsNullOrWhiteSpace(_model.InfoUrl);
    }

    async void OpenMaps_Clicked(object sender, EventArgs e)
    {
        if (_model.Latitude.HasValue && _model.Longitude.HasValue)
            await Map.Default.OpenAsync(_model.Latitude.Value, _model.Longitude.Value, new MapLaunchOptions { Name = _model.Title });
        else
        {
            var q = Uri.EscapeDataString($"{_model.VenueName} {_model.City} {_model.State}");
            await Launcher.Default.OpenAsync($"https://www.google.com/maps/search/?api=1&query={q}");
        }
    }

    async void OpenInfo_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(_model.InfoUrl))
            await Launcher.Default.OpenAsync(_model.InfoUrl);
    }

    async void ExportIcs_Clicked(object sender, EventArgs e)
    {
        var ics = BuildIcs(_model);
        var file = Path.Combine(FileSystem.CacheDirectory, $"{Sanitize(_model.Title)}.ics");
        File.WriteAllText(file, ics);
        await Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = "Add to calendar",
            File = new ShareFile(file)
        });
    }

    static string BuildIcs(BrewEvent e)
    {
        var uid = Guid.NewGuid().ToString();
        var dtStart = e.StartLocal.ToUniversalTime().ToString("yyyyMMdd'T'HHmmss'Z'");
        var dtEnd = (e.EndLocal ?? e.StartLocal.AddHours(2)).ToUniversalTime().ToString("yyyyMMdd'T'HHmmss'Z'");
        var sb = new StringBuilder();
        sb.AppendLine("BEGIN:VCALENDAR");
        sb.AppendLine("VERSION:2.0");
        sb.AppendLine("PRODID:-//BrewScout//Event//EN");
        sb.AppendLine("BEGIN:VEVENT");
        sb.AppendLine($"UID:{uid}");
        sb.AppendLine($"DTSTAMP:{DateTime.UtcNow:yyyyMMdd'T'HHmmss'Z'}");
        sb.AppendLine($"DTSTART:{dtStart}");
        sb.AppendLine($"DTEND:{dtEnd}");
        sb.AppendLine($"SUMMARY:{Escape(e.Title)}");
        sb.AppendLine($"DESCRIPTION:{Escape(e.Description)}");
        sb.AppendLine($"LOCATION:{Escape($"{e.VenueName}, {e.City}, {e.State}")}");
        if (!string.IsNullOrWhiteSpace(e.InfoUrl)) sb.AppendLine($"URL:{e.InfoUrl}");
        sb.AppendLine("END:VEVENT");
        sb.AppendLine("END:VCALENDAR");
        return sb.ToString();

        static string Escape(string? s) => (s ?? "").Replace(",", @"\,").Replace(";", @"\;").Replace("\n", "\\n");
    }
    static string Sanitize(string s) => string.Concat(s.Where(ch => !Path.GetInvalidFileNameChars().Contains(ch)));
}
