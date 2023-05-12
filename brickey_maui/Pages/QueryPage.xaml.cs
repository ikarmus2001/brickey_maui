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
        BindingContext = new QueryPageViewModel((QueryPageModel)query[nameof(QueryPageModel)]);
        (QueryType)query[nameof(QueryType)]);
        cachedElements = ((List<Minifigure>)query[nameof(List<Minifigure>)]);
    }

    private void StatsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var x = e.CurrentSelection.FirstOrDefault() as QueryElement;
        Console.WriteLine(x.ToString());
        ItemClicked(QueryElement x, );
    }
}