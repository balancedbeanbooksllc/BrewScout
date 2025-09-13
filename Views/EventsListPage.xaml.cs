using BrewScout.ViewModels;
using BrewScout.Models;

namespace BrewScout.Views;

public partial class EventsListPage : ContentPage
{
    EventsListViewModel vm = new();
    public EventsListPage()
    {
        InitializeComponent();
        BindingContext = vm;
        CategoryPicker.ItemsSource = vm.Categories;
        CategoryPicker.SelectedItem = "All";
        Search.TextChanged += async (_,__) => await vm.LoadAsync();
        List.ItemsSource = vm.Events;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.LoadAsync();
    }
    private async void AddEvent_Clicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync(nameof(EditEventPage));

    private async void Open_Clicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is BrewEvent ev)
            await Shell.Current.GoToAsync($"{nameof(EventDetailPage)}?id={ev.Id}");
    }
}
