using brickey_maui.Models;
using brickey_maui.Pages;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using static BrickeyCore.QueryModel;

namespace brickey_maui.ViewModel
{
    internal partial class QueryPageViewModel<T> : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<QueryElement> queryElements;

        internal List<T> cachedItems;

        QueryType elementsType;  // might be redundant: id prefix

        internal QueryPageViewModel(QueryPageModel query, QueryType qt)
        {
            this.queryElements = new ObservableCollection<QueryElement>(query.queryElements);
            elementsType = qt;
        }

        internal async void ItemClicked(string itemId)
        {
            var parameters = new Dictionary<string, object>();
            var item = cachedItems.Where(elem => elem.Id == itemId).FirstOrDefault();

            parameters.Add(nameof(item), item);

            switch (elementsType)
            {
                case QueryType.Minifigure:
                    await Shell.Current.GoToAsync(nameof(MinifigureDetailPage), parameters);
                    break;
                //case QueryType.Set:
                //    await Shell.Current.GoToAsync(nameof(SetDetailPage), parameters);
                //    break;
                //case QueryType.Part:
                //    await Shell.Current.GoToAsync(nameof(PartDetailPage), parameters);
                //    break;
                default:
                    throw new Exception();
            }   
        }
    }
}
