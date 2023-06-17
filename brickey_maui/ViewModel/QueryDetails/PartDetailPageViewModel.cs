using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using brickey_maui.Pages.QueryDetails;

namespace brickey_maui.ViewModel.QueryDetails
{
    public partial class PartDetailPageViewModel : ObservableObject
    {
        [ObservableProperty] ImageSource mainImage;
        [ObservableProperty] PartDetails partDetails;
        [ObservableProperty] ObservableCollection<Set> featuringSets;

        private PartDetailPageViewModel() {  }

        public static async Task<PartDetailPageViewModel> Build(Part part)
        {
            var vm = new PartDetailPageViewModel()
            {
                MainImage = part.imageURL
            };
            vm.PartDetails = await RebrickableApiWrapper.GetPartDetails(part.Id);
            return vm;
        }

        public async Task SetClicked(string setId)
        {
            var item = await RebrickableApiWrapper.GetSetsDetails(new[]{ setId });

            var parameters = new Dictionary<string, object>()
            {
                {nameof(item), item[0]}
            };

            await Shell.Current.GoToAsync(nameof(SetDetailPage), parameters);
        }
    }
}
