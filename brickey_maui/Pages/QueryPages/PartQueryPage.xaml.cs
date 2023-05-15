using brickey_maui.Models;
using brickey_maui.ViewModel.QueryPages;
using BrickeyCore.RebrickableModel;
using static BrickeyCore.QueryModel;

namespace brickey_maui.Pages.QueryPages;

public partial class PartQueryPage : ContentPage, IQueryAttributable
{
    public PartQueryPage()
	{
		InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var itemsType = (QueryType)query[nameof(QueryType)];
        var qpModel = (QueryPageModel)query[nameof(QueryPageModel)];

        var b = new PartQueryPageViewModel(qpModel)
        {
            cachedItems = ((PagedResponse<Part>)query["data"]).results
        };
        BindingContext = b;
    }

    private void StatsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        throw new NotImplementedException();
        //var x = e.CurrentSelection.FirstOrDefault() as QueryElement;
        //((PartQueryPageViewModel)BindingContext).ItemClicked(x.id);
    }
}