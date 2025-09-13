namespace BrewScout;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.BreweryDetailPage), typeof(Views.BreweryDetailPage));
        Routing.RegisterRoute(nameof(Views.EditEventPage), typeof(Views.EditEventPage));
        Routing.RegisterRoute(nameof(Views.EventDetailPage), typeof(Views.EventDetailPage));
    }
}
