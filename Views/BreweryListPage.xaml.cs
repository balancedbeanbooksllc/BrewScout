using BrewScout.ViewModels;

namespace BrewScout.Views;

public partial class BreweryListPage : ContentPage
{
    BreweryListViewModel vm;
    public BreweryListPage()
    {
        InitializeComponent();
        vm = Application.Current?.Services?.GetService<BreweryListViewModel>() ?? new BreweryListViewModel(new Services.BreweryService());
        BindingContext = vm;
        Search.TextChanged += async (s, e) => await vm.LoadAsync();
        List.ItemsSource = vm.Breweries;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.LoadAsync();
    }
}
