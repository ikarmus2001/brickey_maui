using brickey_maui.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace brickey_maui.ViewModel
{
    public partial class QueryPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Image> mainImageCarousel;

        [ObservableProperty]
        ObservableCollection<string> statsCollection;

        [ObservableProperty]
        string queryTitleText;

        [ObservableProperty]
        string descriptionText;

        public QueryPageViewModel(QueryPageModel query)
        {
            
        }
    }
}
