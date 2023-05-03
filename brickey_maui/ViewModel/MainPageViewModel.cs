﻿using brickey_maui.Models;
using brickey_maui.Pages;
using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace brickey_maui.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        public static async Task MainPageVM_Loaded()
        {
            var username = await SecureStorage.Default.GetAsync(nameof(AppStoredDataModel.username));
            var password = await SecureStorage.Default.GetAsync(nameof(AppStoredDataModel.password));
            var apiKey = await SecureStorage.Default.GetAsync(nameof(AppStoredDataModel.apiKey));
            if (username == null || password == null) 
            {
                await Shell.Current.GoToAsync(nameof(SetupRebrickablePage));
            }
            // TODO can be improved
            await RebrickableApiWrapper.Setup(apiKey, username, password);
        }

        public static async Task MyProfileBtn_Clicked()
        {
            UserProfile up = await RebrickableApiWrapper.GetUserProfile();
            var navigationParam = new Dictionary<string, object>()
            {
                {"Profile", up }
            };
            await Shell.Current.GoToAsync(nameof(UserProfilePage), navigationParam);
        }

        internal async static Task CollectionBtn_Clicked()
        {
            
        }

        internal async static Task SearchHistoryBtn_Clicked()
        {
            
        }
    }
}
