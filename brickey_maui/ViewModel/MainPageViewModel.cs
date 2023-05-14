using brickey_maui.Models;
using brickey_maui.Pages;
using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
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
        public bool minifiguresRadioChecked = true;

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

        internal async void SearchBtn_Clicked()
        {
            QueryModel qm;
            QueryPageModel result = new QueryPageModel();
            QueryType qt;
            var navigationParam = new Dictionary<string, object>();
            if (MinifiguresRadioChecked)
            {
                qt = QueryType.Minifigure;
                qm = UnparseSearchbarText(SearchbarText, QueryType.Minifigure);

                var data = await RebrickableApiWrapper.RetrieveDatabaseInfo<Minifigure>(qm);
                result = data.ToQueryPageModel();

                navigationParam.Add(nameof(List<Minifigure>), qm);
                navigationParam.Add(nameof(data), data);
            }
            else if (PartRadioChecked)
            {
                qt = QueryType.Part;
                qm = UnparseSearchbarText(SearchbarText, QueryType.Part);

                var data = await RebrickableApiWrapper.RetrieveDatabaseInfo<Part>(qm);
                result = data.ToQueryPageModel();

                navigationParam.Add(nameof(List<Part>), qm);
                navigationParam.Add(nameof(data), data);
            }
            else if (SetRadioChecked)
            {
                qt = QueryType.Set;
                qm = UnparseSearchbarText(SearchbarText, QueryType.Set);
                
                var data = await RebrickableApiWrapper.RetrieveDatabaseInfo<Set>(qm);
                result = data.ToQueryPageModel();

                navigationParam.Add(nameof(List<Set>), qm);
                navigationParam.Add(nameof(data), data);
            }
            else throw new Exception();

            
            navigationParam.Add(nameof(QueryPageModel), result);
            navigationParam.Add(nameof(QueryType), qt);
            await Shell.Current.GoToAsync(nameof(QueryPage), navigationParam);
        }

        public static async void MyProfileBtn_Clicked()
        {
            UserProfile up = await RebrickableApiWrapper.GetUserProfile();
            var navigationParam = new Dictionary<string, object>()
            {
                {"Profile", up }
            };
            await Shell.Current.GoToAsync(nameof(UserProfilePage), navigationParam);
        }

        internal static async Task CollectionBtn_Clicked()
        {
            
        }

        

        private static QueryModel UnparseSearchbarText(string searchbarText, QueryType qtype)
        {
            var p = new Dictionary<string, string>()
            {
                {"search", searchbarText }
            };

            return new QueryModel()
            {
                queryType = qtype,
                parameters = p
            };
        }

        internal async static Task SearchHistoryBtn_Clicked()
        {
            
        }
    }
}
