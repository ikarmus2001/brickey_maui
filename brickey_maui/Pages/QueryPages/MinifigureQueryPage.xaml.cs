using brickey_maui.Models;
using brickey_maui.ViewModel.QueryPages;
using BrickeyCore.RebrickableModel;
using static BrickeyCore.QueryModel;

namespace brickey_maui.Pages.QueryPages;

public partial class MinifigureQueryPage : ContentPage, IQueryAttributable
{
    public MinifigureQueryPage()
	{
		InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var qpModel = (QueryPageModel)query[nameof(QueryPageModel)];

        var b = new MinifigureQueryPageViewModel(qpModel)
        {
            cachedItems = ((PagedResponse<Minifigure>)query["data"]).results
        };
        BindingContext = b;
    }

    private void StatsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var chosenMinifigure = (QueryElement)e.CurrentSelection.FirstOrDefault();
        ((MinifigureQueryPageViewModel)BindingContext).ItemClicked(chosenMinifigure.id);
    }
}