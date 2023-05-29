using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace brickey_maui.ViewModel.QueryDetails
{
    public partial class SetDetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ImageSource mainImage;

        //[ObservableProperty]
        //ObservableCollection<Set> featuringSets;

        //[ObservableProperty]
        //ObservableCollection<PartOfSet> partsUsed;

        private PagedResponse<PartOfSet> pagedPartsOfSet;

        private SetDetailPageViewModel() {  }

        public static async Task<SetDetailPageViewModel> Build(Set set)
        {
            var vm = new SetDetailPageViewModel()
            {
                MainImage = ImageSource.FromUri(new Uri(set.imageURL ??
                                                        "https://cdn-icons-png.flaticon.com/512/1548/1548682.png"))
            };

            vm.pagedPartsOfSet = await RebrickableApiWrapper.GetSetsParts(set.Id);

            return vm;
        }
    }
}



