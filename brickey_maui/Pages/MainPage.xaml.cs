using brickey_maui.Models;
using brickey_maui.Pages;
using brickey_maui.ViewModel;
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
        var x = new QueryModel()
        {
            Title = "cokolwiek",
            Description = "Przykładowy opis",
            Statistics = new List<string>()
            {
                "stat1", "stat2"
            },
            MainImages = new List<Image>() { }
        };
        var y = new QueryPageViewModel(x);

        var z = new QueryPage(y);

        await Navigation.PushAsync(z);
        try
        {
            //Uri uri = new Uri("https://www.rebrickable.com");
            //await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            // An unexpected error occurred. No browser may be installed on the device.
        }

    }

    private async void ShowUserProfileClicked(object sender, EventArgs e)
    {
        //await Shell.Current.GoToAsync(nameof(SetupRebrickablePage));
        OpenUserProfilePage();
    }

    private async void OpenUserProfilePage()
    {
        await Shell.Current.GoToAsync(nameof(UserProfilePage));
    }
}

