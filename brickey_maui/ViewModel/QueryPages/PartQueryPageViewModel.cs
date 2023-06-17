﻿using brickey_maui.Models;
using brickey_maui.Pages.QueryDetails;
using BrickeyCore.RebrickableModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace brickey_maui.ViewModel.QueryPages
{
    public partial class PartQueryPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<QueryElement> queryElements;

        public List<Part> cachedItems;
        
        public PartQueryPageViewModel(QueryPageModel query)
        {
            queryElements = new ObservableCollection<QueryElement>(query.queryElements);
        }

        public async void ItemClicked(string itemId)
        {
            var parameters = new Dictionary<string, object>();
            var item = cachedItems.FirstOrDefault(elem => elem.Id == itemId);

            parameters.Add(nameof(item), item);

            await Shell.Current.GoToAsync(nameof(PartDetailPage), parameters);
        }
    }
}
