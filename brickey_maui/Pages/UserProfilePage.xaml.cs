using BrickeyCore;
using BrickeyCore.RebrickableModel;
using brickey_maui.ViewModel;

namespace brickey_maui.Pages;

public partial class UserProfilePage : ContentPage
{
	UserProfile userProfile;

    public UserProfilePage()
	{
		InitializeComponent();
	}

    public UserProfilePage(UserProfileViewModel userProfileVM)
    {
        InitializeComponent();
        BindingContext = userProfileVM;
    }

    private async void OnLoaded(object sender, EventArgs args)
    {
        await RetrieveUserData();
        FillView();
    }

    private async Task RetrieveUserData()
	{
        userProfile = await RebrickableApiWrapper.GetUserProfile();
	}

    private void FillView()
    {
  //      ProfilePicture.Source;
		//usernameLbl.Text = userProfile.username;
		//userIdLbl.Text = userProfile.user_id.ToString();
		//emailLbl.Text = userProfile.email;
    }
}