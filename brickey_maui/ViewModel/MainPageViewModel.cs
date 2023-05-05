using brickey_maui.Models;
using brickey_maui.Pages;
using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using static BrickeyCore.QueryModel;

namespace brickey_maui.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public string searchbarText;

        [ObservableProperty]
        public bool setRadioChecked;

        [ObservableProperty]
        public bool minifiguresRadioChecked;

        [ObservableProperty]
        public bool partRadioChecked;

        
        public static async void MainPageVM_Loaded()
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

        [RelayCommand]
        internal async void SearchBtn_Clicked()
        {
            QueryModel qm;
            QueryPageModel result = new QueryPageModel();
            if (MinifiguresRadioChecked)
            {
                qm = UnparseSearchbarText(SearchbarText, QueryType.MiniFigure);
                result = (await RebrickableApiWrapper.RetrieveDatabaseInfo<Minifigure>(qm)).ToQueryPageModel();
            }
            else if (PartRadioChecked)
            {
                //qm = UnparseSearchbarText(SearchbarText, QueryType.Part);
                //result = (await RebrickableApiWrapper.RetrieveDatabaseInfo<Part>(qm)).ToQueryPageModel();
            }
            else if (SetRadioChecked)
            {
                //qm = UnparseSearchbarText(SearchbarText, QueryType.Set);
                //result = (await RebrickableApiWrapper.RetrieveDatabaseInfo<BrickeyCore.RebrickableModel.Set>(qm)).ToQueryPageModel();
            }
            else throw new Exception();

            var navigationParam = new Dictionary<string, object>()
            {
                {nameof(QueryPageModel), result}
            };
            await Shell.Current.GoToAsync(nameof(QueryPage), navigationParam);
        }

        [RelayCommand]
        public async void MyProfileBtn_Clicked()
        {
            UserProfile up = await RebrickableApiWrapper.GetUserProfile();
            var navigationParam = new Dictionary<string, object>()
            {
                {"Profile", up }
            };
            await Shell.Current.GoToAsync(nameof(UserProfilePage), navigationParam);
        }

        [RelayCommand]
        internal async Task CollectionBtn_Clicked()
        {
            
        }

        

        private static QueryModel UnparseSearchbarText(string searchbarText, QueryType qtype)
        {
            var p = new Dictionary<string, string>()
            {
                {"", searchbarText }
            };

            return new QueryModel()
            {
                queryType = qtype,
                parameters = p
            };
        }

        [RelayCommand]
        internal async static Task SearchHistoryBtn_Clicked()
        {
            
        }
    }
}
