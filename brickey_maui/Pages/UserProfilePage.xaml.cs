using brickey_maui.ViewModel;
using BrickeyCore.RebrickableModel;


namespace brickey_maui.Pages;

[QueryProperty(nameof(profile), "Profile")]
public partial class UserProfilePage : ContentPage
{
    public UserProfile profile
    {
        set { UnpackProfile(value); }
    }

	public UserProfilePage()
    {
        InitializeComponent();
    }

    private void UnpackProfile(UserProfile value)
    {
        if (value != null)
        {
            BindingContext = new UserProfileViewModel(value);
        }
    }

    private async void Button_OnClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SetupRebrickablePage));
    }
}