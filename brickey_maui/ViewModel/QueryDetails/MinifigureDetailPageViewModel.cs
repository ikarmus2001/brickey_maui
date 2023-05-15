using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace brickey_maui.ViewModel.QueryDetails
{
    internal partial class MinifigureDetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ImageSource mainImage;

        [ObservableProperty]
        ObservableCollection<Set> featuringSets;

        [ObservableProperty]
        ObservableCollection<MinifigureParts> partsUsed;

        private MinifigureDetailPageViewModel(PagedResponse<MinifigureParts> x, Minifigure mf)
        {
            mainImage = ImageSource.FromUri(new Uri(mf.imageURL));
            partsUsed = new ObservableCollection<MinifigureParts>(x.results);
        }

        internal static async Task<MinifigureDetailPageViewModel> Build(Minifigure mf)
        {
            PagedResponse<MinifigureParts> x = await RebrickableApiWrapper.GetMinifigureParts(mf.Id);

            return new MinifigureDetailPageViewModel(x, mf);
        }
    }
}
