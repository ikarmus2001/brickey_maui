using brickey_maui.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace brickey_maui.ViewModel
{
    public partial class QueryPageViewModel : ObservableObject, IQueryAttributable
    {

        [ObservableProperty]
        ObservableCollection<Image> mainImageCarousel;

        [ObservableProperty]
        ObservableCollection<string> statsCollection;

        [ObservableProperty]
        string queryTitleText;

        [ObservableProperty]
        string descriptionText;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var qm = (QueryModel)query[nameof(QueryModel)];

            MainImageCarousel = new ObservableCollection<Image>(qm.MainImages);
            QueryTitleText = qm.Title;
            DescriptionText = qm.Description;
            StatsCollection = new ObservableCollection<string>(qm.Statistics);
        }

        [RelayCommand]
        void ChangeTitle(string title)
        {
            //queryTitleText = title.Trim();
        }
    }
}
