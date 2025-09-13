using BrewScout.Models;

namespace BrewScout.Views;

public partial class TastingNotesPage : ContentPage
{
    public TastingNotesPage() => InitializeComponent();

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        List.ItemsSource = await App.NotesDb.GetAllAsync();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await App.NotesDb.SaveAsync(new BeerNote{ BeerName="Sample", Style="IPA", Rating=4, Notes="Citrus, hazy."});
        List.ItemsSource = await App.NotesDb.GetAllAsync();
    }
}
