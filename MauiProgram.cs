using BrewScout.Services;
using BrewScout.ViewModels;
using Microsoft.Maui.Controls.Compatibility;

namespace BrewScout;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiMaps()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // DI registrations
        builder.Services.AddSingleton<BreweryService>();
        builder.Services.AddSingleton<BreweryListViewModel>();
        builder.Services.AddSingleton<EventsListViewModel>();

        return builder.Build();
    }
}
