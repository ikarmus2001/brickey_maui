using brickey_maui.Pages;
using BrickeyCore;
using CommunityToolkit.Maui.Alerts;
using ToastDuration = CommunityToolkit.Maui.Core.ToastDuration;

namespace brickey_maui;

public partial class SetupRebrickablePage : ContentPage
{
    public SetupRebrickablePage()
	{
		InitializeComponent();
	}

    private async void SaveBtn_Clicked(object sender, EventArgs e)
    {
        MauiProgram.SaveUserLoginData(UsernameEntry.Text, PasswordEntry.Text, ApiKeyEntry.Text);
        if (await RebrickableApiWrapper.Setup(ApiKeyEntry.Text, UsernameEntry.Text, PasswordEntry.Text))
        {
            await Shell.Current.GoToAsync("..");
        }
        else
        {
            var t = Toast.Make("Login failed, try again");
            await t.Show();
        }
    }

    private async void GetApiKey_Click(object sender, EventArgs e)
    {
        Uri uri = new Uri("https://rebrickable.com/login/?next=%2Fapi%2F");
        _ = await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }
}