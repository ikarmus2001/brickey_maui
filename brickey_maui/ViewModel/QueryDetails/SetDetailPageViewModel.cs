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
        //ObservableCollection<PartOfSet> partsUsed;

        private SetDetailPageViewModel(Set set, List<PartOfSet> includedPartOfSet)
        {
            //mainImage = ImageSource.FromUri(new Uri(mf.imageURL));
            //partsUsed = new ObservableCollection<PartOfSet>(x.results);
        }

        internal static async Task<SetDetailPageViewModel> Build(Set set)
        {

            PagedResponse<PartOfSet> x = await RebrickableApiWrapper.GetSetsParts(set.Id);

            return new SetDetailPageViewModel(set, x.results);
        }
    }
}



