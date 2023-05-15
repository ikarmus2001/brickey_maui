using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace brickey_maui.ViewModel.QueryDetails
{
    internal partial class MinifigureDetailPageViewModel : ObservableObject
    {
        [ObservableProperty] private ImageSource mainImage;

        [ObservableProperty] private string name;

        [ObservableProperty] private string id;

        [ObservableProperty] private ObservableCollection<Set> featuringSets;

        [ObservableProperty] private ObservableCollection<MinifigureParts> partsUsed;

        PagedResponse<MinifigureParts> pagedParts;

        private MinifigureDetailPageViewModel()
        {
            
        }

        internal static async Task<MinifigureDetailPageViewModel> Build(Minifigure mf)
        {
            var x = new MinifigureDetailPageViewModel()
            {
                name = mf.name,
                id = mf.Id,
                mainImage = ImageSource.FromUri(new Uri(mf.imageURL)),
                pagedParts = await RebrickableApiWrapper.GetMinifigureParts(mf.Id)
            };

            x.partsUsed = new ObservableCollection<MinifigureParts>(x.pagedParts.results);
            return x;
        }
    }
}
