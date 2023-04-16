using brickey_maui.Pages;
using BrickeyCore;

namespace brickey_maui;

public partial class MainPage : ContentPage
{
	//int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
        try
        {
            Uri uri = new Uri("https://www.rebrickable.com");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            // An unexpected error occurred. No browser may be installed on the device.
        }

    }

    private async void ChangePage(object sender, EventArgs e)
    {
        if (!RebrickableApiWrapper.isConnected)
            await Shell.Current.GoToAsync(nameof(SetupRebrickablePage));
        OpenUserProfilePage();
    }

    private async void OpenUserProfilePage()
    {
        await Shell.Current.GoToAsync(nameof(UserProfilePage));
    }
}

