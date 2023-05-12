using brickey_maui.Models;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using static BrickeyCore.QueryModel;

namespace brickey_maui.ViewModel
{
    internal partial class QueryPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<QueryElement> queryElements;

        QueryType elementsType;  // might be redundant: set_num prefix

        internal QueryPageViewModel(QueryPageModel query, QueryType qt)
        {
            this.queryElements = new ObservableCollection<QueryElement>(query.queryElements);
            elementsType = qt;
        }

        internal async void ItemClicked(QueryElement x)
        {
            switch (elementsType)
            {
                case QueryType.MiniFigure:
                    await GetMinifigure(x.id)
                    break;

            }
            
            await Shell.Current.
    }
}
