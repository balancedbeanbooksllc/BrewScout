using BrewScout.Models;

namespace BrewScout.Views;

public partial class EditEventPage : ContentPage
{
    public EditEventPage()
    {
        InitializeComponent();
        CategoryPicker.ItemsSource = new List<string> { "Trivia","Live Music","Food Truck","Release","Festival","General" };
        DatePick.Date = DateTime.Today.AddDays(1);
        TimePick.Time = new TimeSpan(19,0,0);
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        var ev = new BrewEvent{
            Title = TitleEntry.Text ?? "",
            Description = DescEditor.Text ?? "",
            StartLocal = DatePick.Date.Add(TimePick.Time),
            VenueName = VenueEntry.Text ?? "",
            City = CityEntry.Text ?? "",
            Category = CategoryPicker.SelectedItem?.ToString() ?? "General"
        };
        await App.EventsDb.SaveAsync(ev);
        await Shell.Current.GoToAsync("..");
    }
}
