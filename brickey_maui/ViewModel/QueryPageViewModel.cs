using brickey_maui.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace brickey_maui.ViewModel
{
    // [QueryProperty("QueryModel", "QueryModel")]
    public partial class QueryPageViewModel : ObservableObject //, IQueryAttributable
    {

        [ObservableProperty]
        ObservableCollection<Image> mainImageCarousel;

        [ObservableProperty]
        ObservableCollection<string> statsCollection;

        [ObservableProperty]
        string queryTitleText;

        [ObservableProperty]
        string descriptionText;

        public QueryPageViewModel() { }

        public QueryPageViewModel(QueryModel qm) 
        {
            MainImageCarousel = new ObservableCollection<Image>(qm.MainImages);
            QueryTitleText = qm.Title;
            DescriptionText = qm.Description;
            StatsCollection = new ObservableCollection<string>(qm.Statistics);
        }

        //public void ApplyQueryAttributes(IDictionary<string, object> query)
        //{
        //    var x = (QueryModel)query["QueryModel"];
        //    MainImageCarousel = new ObservableCollection<Image>(x.MainImages);
        //    QueryTitleText = x.Title;
        //    DescriptionText = x.Description;
        //    StatsCollection = new ObservableCollection<string>(x.Statistics);
        //}

        [RelayCommand]
        void ChangeTitle(string title)
        {
            queryTitleText = title.Trim();
        }
    }
}
