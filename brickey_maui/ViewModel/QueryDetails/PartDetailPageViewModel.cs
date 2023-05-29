using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

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
            vm.partDetails = await RebrickableApiWrapper.GetPartDetails(part.Id);
            //vm.partDetails.

            return vm;
        }
    }
}
