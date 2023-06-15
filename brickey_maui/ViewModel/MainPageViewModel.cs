using brickey_maui.Models;
using brickey_maui.Pages;
using brickey_maui.Pages.QueryPages;
using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
#if ANDROID
using Java.Lang;
using Java.Security;
#endif
using static BrickeyCore.QueryModel;
using Exception = System.Exception;

namespace brickey_maui.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty] private string searchbarText;

        [ObservableProperty] private bool setRadioChecked;

        [ObservableProperty] private bool minifiguresRadioChecked = true;

        [ObservableProperty] private bool partRadioChecked;

        
        public static async void MainPageVM_Loaded()
        {
            var username = await SecureStorage.Default.GetAsync(nameof(AppStoredDataModel.username));
            var password = await SecureStorage.Default.GetAsync(nameof(AppStoredDataModel.password));
            var apiKey = await SecureStorage.Default.GetAsync(nameof(AppStoredDataModel.apiKey));
            if (username == "" || password == "" || username == null || password == null) 
            {
                await Shell.Current.GoToAsync(nameof(SetupRebrickablePage));
            }
            else
            {
                await RebrickableApiWrapper.Setup(apiKey, username, password);
            }
        }

        /// <summary>
        /// TODO: Refactor
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        public async void SearchBtn_Clicked()
        {
            QueryModel qm;
            QueryPageModel result;
            var navigationParam = new Dictionary<string, object>();
            if (MinifiguresRadioChecked)
            {
                qm = UnparseSearchbarText(SearchbarText, QueryType.Minifigure);

                var data = await RebrickableApiWrapper.RetrieveDatabaseInfo<Minifigure>(qm);

                if (data.count == 0)
                {
                    var text = "Nie znaleziono minifigurek dla tej frazy";
                    var t = CommunityToolkit.Maui.Alerts.Toast.Make(text);
                    await t.Show(new CancellationToken());
                    return;
                }

                result = data.ToQueryPageModel();

                navigationParam.Add(nameof(List<Minifigure>), qm);
                navigationParam.Add(nameof(data), data);
                navigationParam.Add(nameof(QueryPageModel), result);

                await Shell.Current.GoToAsync(nameof(MinifigureQueryPage), navigationParam);
            }
            else if (PartRadioChecked)
            {
                qm = UnparseSearchbarText(SearchbarText, QueryType.Part);

                var data = await RebrickableApiWrapper.RetrieveDatabaseInfo<Part>(qm);
                if (data.count == 0)
                {
                    var text = "Nie znaleziono części dla tej frazy";
                    var t = CommunityToolkit.Maui.Alerts.Toast.Make(text);
                    await t.Show(new CancellationToken());
                    return;
                }

                result = data.ToQueryPageModel();

                navigationParam.Add(nameof(List<Part>), qm);
                navigationParam.Add(nameof(data), data);
                navigationParam.Add(nameof(QueryPageModel), result);

                await Shell.Current.GoToAsync(nameof(PartQueryPage), navigationParam);
            }
            else if (SetRadioChecked)
            {
                qm = UnparseSearchbarText(SearchbarText, QueryType.Set);

                var data = await RebrickableApiWrapper.RetrieveDatabaseInfo<Set>(qm);

                if (data.count == 0)
                {
                    var text = "Nie znaleziono zestawów dla tej frazy";
                    var t = CommunityToolkit.Maui.Alerts.Toast.Make(text);
                    await t.Show(new CancellationToken());
                    return;
                }

                result = data.ToQueryPageModel();

                navigationParam.Add(nameof(List<Set>), qm);
                navigationParam.Add(nameof(data), data);

                navigationParam.Add(nameof(QueryPageModel), result);
                await Shell.Current.GoToAsync(nameof(SetQueryPage), navigationParam);
            }
            else throw new Exception();
        }
        
        private static QueryModel UnparseSearchbarText(string searchbarText, QueryType qtype)
        {
            var p = new Dictionary<string, string>()
            {
                {"search", searchbarText }
            };

            return new QueryModel(qtype, p);
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

        public async static Task SearchHistoryBtn_Clicked()
        {
            
        }

        public static async Task CollectionBtn_Clicked()
        {

        }
    }
}
