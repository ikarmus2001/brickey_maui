using brickey_maui.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace brickey_maui.ViewModel
{
    internal partial class QueryPageViewModel : ObservableObject
    {
        [ObservableProperty]
        List<QueryElement> queryElements;

        internal QueryPageViewModel(QueryPageModel query)
        {
            this.queryElements = query.queryElements;
        }
    }
}
