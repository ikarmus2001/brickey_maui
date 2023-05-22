using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using brickey_maui.Pages.QueryDetails;

namespace brickey_maui.ViewModel.QueryDetails
{
    public partial class MinifigureDetailPageViewModel : ObservableObject
    {
        [ObservableProperty] private ImageSource mainImage;

        [ObservableProperty] private string name;

        [ObservableProperty] private string id;

        [ObservableProperty] private ObservableCollection<Set> featuringSets;

        [ObservableProperty] private ObservableCollection<PartOfSet> partsUsed;

        PagedResponse<PartOfSet> pagedParts;

        private MinifigureDetailPageViewModel()
        {
            
        }

        public static async Task<MinifigureDetailPageViewModel> Build(Minifigure mf)
        {
            var x = new MinifigureDetailPageViewModel()
            {
                Name = mf.name,
                Id = mf.Id,
                MainImage = ImageSource.FromUri(new Uri(mf.imageURL ?? "https://cdn-icons-png.flaticon.com/512/1548/1548682.png"))
            };
            x.pagedParts = await RebrickableApiWrapper.GetMinifigureParts(mf.Id);

            x.PartsUsed = new ObservableCollection<PartOfSet>(x.pagedParts.results);
            return x;
        }

        public async Task PartClicked()
        {
            await Shell.Current.GoToAsync(nameof(PartDetailPage));
        }
    }
}
