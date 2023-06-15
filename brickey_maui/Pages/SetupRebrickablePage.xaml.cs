using BrickeyCore;
using CommunityToolkit.Maui.Alerts;

namespace brickey_maui;

public partial class SetupRebrickablePage : ContentPage
{
    public SetupRebrickablePage()
	{
		InitializeComponent();
	}

    private async void SaveBtn_Clicked(object sender, EventArgs e)
    {
        if (!ValidateForm())
            return;

        MauiProgram.SaveUserLoginData(UsernameEntry.Text, PasswordEntry.Text, ApiKeyEntry.Text);
        if (!await RebrickableApiWrapper.Setup(ApiKeyEntry.Text, UsernameEntry.Text, PasswordEntry.Text))
        {
            ToastLoginFailed("Login failed, try again");
            return;
        }
        await Shell.Current.GoToAsync("..");
    }

    private async void ToastLoginFailed(string message)
    {
        var t = Toast.Make(message);
        await t.Show();
    }

    private bool ValidateForm()
    {
#nullable enable
        string?[] contents = { UsernameEntry.Text, PasswordEntry.Text, ApiKeyEntry.Text };
        foreach (string? t in contents)
        {
            if (t?.Trim() is null or "")
            {
                ToastLoginFailed("Form incomplete");
                return false;
            }
        }
        return true;
#nullable disable
    }

    private async void GetApiKey_Click(object sender, EventArgs e)
    {
        Uri uri = new Uri("https://rebrickable.com/login/?next=%2Fapi%2F");
        _ = await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}