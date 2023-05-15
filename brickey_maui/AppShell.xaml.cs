using brickey_maui.Pages;
using brickey_maui.Pages.QueryPages;
using brickey_maui.Pages.QueryDetails;

namespace brickey_maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(SetupRebrickablePage), typeof(SetupRebrickablePage));
        Routing.RegisterRoute(nameof(UserProfilePage), typeof(UserProfilePage));

        Routing.RegisterRoute(nameof(MinifigureQueryPage), typeof(MinifigureQueryPage));
        Routing.RegisterRoute(nameof(SetQueryPage), typeof(SetQueryPage));
        Routing.RegisterRoute(nameof(PartQueryPage), typeof(PartQueryPage));

        Routing.RegisterRoute(nameof(MinifigureDetailPage), typeof(MinifigureDetailPage));
        Routing.RegisterRoute(nameof(SetDetailPage), typeof(SetDetailPage));
        Routing.RegisterRoute(nameof(PartDetailPage), typeof(PartDetailPage));
    }
}
