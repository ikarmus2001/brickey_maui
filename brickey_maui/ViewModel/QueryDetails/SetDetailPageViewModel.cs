using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace brickey_maui.ViewModel.QueryDetails
{
    internal partial class SetDetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ImageSource mainImage;

        //[ObservableProperty]
        //ObservableCollection<Set> featuringSets;

        //[ObservableProperty]
        //ObservableCollection<MinifigureParts> partsUsed;

        private SetDetailPageViewModel(PagedResponse<MinifigureParts> x, Minifigure mf)
        {
            mainImage = ImageSource.FromUri(new Uri(mf.imageURL));
            //partsUsed = new ObservableCollection<MinifigureParts>(x.results);
        }

        internal static async Task<SetDetailPageViewModel> Build(Minifigure mf)
        {
            throw new NotImplementedException();
            //PagedResponse<MinifigureParts> x = await RebrickableApiWrapper.GetMinifigureParts(mf.Id);

            //return new SetDetailPageViewModel(x, mf);
        }
    }
}
