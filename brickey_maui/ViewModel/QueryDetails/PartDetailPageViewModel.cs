using BrickeyCore;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace brickey_maui.ViewModel.QueryDetails
{
    internal partial class PartDetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ImageSource mainImage;

        //[ObservableProperty]
        //ObservableCollection<Set> featuringSets;

        //[ObservableProperty]
        //ObservableCollection<MinifigureParts> partsUsed;

        //private PartDetailPageViewModel(PagedResponse<> x, Minifigure mf)
        //{
        //    mainImage = ImageSource.FromUri(new Uri(mf.imageURL));
        //    //partsUsed = new ObservableCollection<MinifigureParts>(x.results);
        //}

        internal static async Task<PartDetailPageViewModel> Build(Part part)
        {
            throw new NotImplementedException();
            //PagedResponse<MinifigureParts> x = await RebrickableApiWrapper.GetMinifigureParts(part.Id);

            //return new MinifigureDetailPageViewModel(x, part);
        }
    }
}
