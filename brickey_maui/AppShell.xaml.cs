using brickey_maui.Pages;

namespace brickey_maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(SetupRebrickablePage), typeof(SetupRebrickablePage));
        Routing.RegisterRoute(nameof(UserProfilePage), typeof(UserProfilePage));
    }
}
