﻿using BrickeyCore.RebrickableModel;
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
        ImageSource profilePicture;

        public UserProfileViewModel(UserProfile profile)
        {
            profilePicture = ImageSource.FromUri(new Uri(profile.avatar_img));
            userId = profile.user_id;
            email = profile.email;
            username = profile.username;
        }
    }
}
