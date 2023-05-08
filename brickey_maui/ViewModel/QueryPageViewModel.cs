using brickey_maui.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace brickey_maui.ViewModel
{
    internal partial class QueryPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<QueryElement> queryElements;

        internal QueryPageViewModel(QueryPageModel query)
        {
            this.queryElements = new ObservableCollection<QueryElement>(query.queryElements);
        }
    }
}
