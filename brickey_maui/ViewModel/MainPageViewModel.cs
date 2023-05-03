using brickey_maui.Models;
using brickey_maui.Pages;
using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Runtime.CompilerServices;

namespace brickey_maui.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public string searchbarText;

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

        //private void OnSearchbarTextChanged(value)
        //{

        //}

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

        internal async static Task SearchBtn_Clicked()
        {
            //QueryModel qm = await UnparseSearchbarText(searchbarText);
            //QueryPageModel result = await qm.RetrieveDatabaseInfo();

            //var navigationParam = new Dictionary<string, object>()
            //{
            //    {nameof(QueryPageModel), result }
            //};
            //await Shell.Current.GoToAsync(nameof(QueryPage), navigationParam);
        }

        private static Task<QueryModel> UnparseSearchbarText(string searchbarText)
        {
            throw new NotImplementedException();
        }

        internal async static Task SearchHistoryBtn_Clicked()
        {
            
        }
    }
}
