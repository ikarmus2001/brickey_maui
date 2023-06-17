using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace brickey_maui.ViewModel.QueryDetails
{
    public partial class SetDetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ImageSource mainImage;

        [ObservableProperty] private string name;

        [ObservableProperty] private string id;

        [ObservableProperty]
        private PagedResponse<PartOfSet> pagedPartsOfSet;

        private SetDetailPageViewModel() {  }

        public static async Task<SetDetailPageViewModel> Build(Set set)
        {
            var vm = new SetDetailPageViewModel()
            {
                Name = set.name,
                Id = set.Id,
                MainImage = ImageSource.FromUri(new Uri(set.imageURL ??
                                                        "https://cdn-icons-png.flaticon.com/512/1548/1548682.png"))
            };

            vm.PagedPartsOfSet = await RebrickableApiWrapper.GetSetsParts(set.Id);

            return vm;
        }
    }
}



