using brickey_maui.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace brickey_maui.ViewModel
{
    internal partial class QueryDetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        List<ImageSource> images;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        string description;

        internal QueryDetailPageViewModel(QueryDetailModel query)
        {
            images = query.MainImages;
            title = query.Title;
            description = query.Description;
            // Statistics
        }
    }
}
