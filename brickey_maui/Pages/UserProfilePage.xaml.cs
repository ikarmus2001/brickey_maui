using brickey_maui.ViewModel;
using BrickeyCore.RebrickableModel;

namespace brickey_maui.Pages;

public partial class UserProfilePage : ContentPage
{
	UserProfile userProfile;

    public UserProfilePage(UserProfileViewModel userProfileVM)
    {
        InitializeComponent();
        BindingContext = userProfileVM;
    }

    private async void OnLoaded(object sender, EventArgs args)
    {
        //await RetrieveUserData();
    }
}