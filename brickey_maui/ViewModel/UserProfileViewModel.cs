using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace brickey_maui.ViewModel
{
    public partial class UserProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        string username;

        [ObservableProperty]
        int userId;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        Image profilePicture;

        public UserProfileViewModel(UserProfile userProfile)
        {
            username = userProfile.username;
            userId = userProfile.user_id;
            email = userProfile.email;
            profilePicture = (Image)userProfile.avatar_img;
        }
    }
}
