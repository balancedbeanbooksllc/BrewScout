using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BrewScout.Models;

namespace BrewScout.ViewModels;

[QueryProperty(nameof(Id), "id")]
public partial class EditEventViewModel : ObservableObject
{
    [ObservableProperty] int id;
    [ObservableProperty] BrewEvent model = new();

    public async Task InitAsync()
    {
        if (Id != 0)
            Model = await App.EventsDb.GetAsync(Id) ?? new BrewEvent();
    }

    [RelayCommand]
    public async Task SaveAsync()
    {
        await App.EventsDb.SaveAsync(Model);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task DeleteAsync()
    {
        if (Id == 0) return;
        await App.EventsDb.DeleteAsync(Model);
        await Shell.Current.GoToAsync("..");
    }
}
