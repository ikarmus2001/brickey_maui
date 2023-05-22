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

        private PartDetailPageViewModel(PartDetails pd, ObservableCollection<Set> featSets)
        {
            mainImage = ImageSource.FromUri(new Uri(pd.imageURL));
            featuringSets = featSets;
            //partsUsed = new ObservableCollection<PartOfSet>(x.results);
        }

        public static async Task<PartDetailPageViewModel> Build(Part part)
        {
            ObservableCollection<Set> featuringSets = null;
            PartDetails pd = await RebrickableApiWrapper.GetPartDetails(part.Id);

            //if (pd.external_ids.Brickset. > 0)
            //    featuringSets = new ObservableCollection<Set>(await RebrickableApiWrapper.GetSetsDetails(pd.external_ids.Brickset));

            return new PartDetailPageViewModel(pd, featuringSets);
        }
    }
}
