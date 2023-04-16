using BrickeyCore;
using BrickeyCore.RebrickableModel;

namespace brickey_maui.Pages;

public partial class UserProfilePage : ContentPage
{
	UserProfile userProfile;

    public UserProfilePage()
	{
		InitializeComponent();
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
		usernameLbl.Text = userProfile.Username;
		userIdLbl.Text = userProfile.UserID.ToString();
		emailLbl.Text = userProfile.Email;
    }
}