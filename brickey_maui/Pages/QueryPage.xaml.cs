using brickey_maui.Models;
using brickey_maui.ViewModel;
using BrickeyCore.RebrickableModel;
using static BrickeyCore.QueryModel;

namespace brickey_maui.Pages;

public partial class QueryPage : ContentPage, IQueryAttributable
{
    public QueryPage()
	{
		InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var itemsType = (QueryType)query[nameof(QueryType)];

        //Type tmp = typeof(Minifigure);
        var b = new QueryPageViewModel<Minifigure>(
            (QueryPageModel)query[nameof(QueryPageModel)],
            itemsType);

        BindingContext = b;
        
        switch(itemsType)
        {
            case QueryType.Minifigure:
                b.cachedItems = ((PagedResponse<Minifigure>)query["data"]).results;
                break;
        }

        b.cachedItems = ((PagedResponse<dynamic>)query["data"]).results;
    }

    private void StatsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var x = e.CurrentSelection.FirstOrDefault() as QueryElement;
        ((QueryPageViewModel)BindingContext).ItemClicked(x.id);
    }
}