using brickey_maui.Models;
using brickey_maui.ViewModel.QueryPages;
using BrickeyCore.RebrickableModel;
using static BrickeyCore.QueryModel;

namespace brickey_maui.Pages.QueryPages;

public partial class SetQueryPage : ContentPage, IQueryAttributable
{
    public SetQueryPage()
	{
		InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var qpModel = (QueryPageModel)query[nameof(QueryPageModel)];
        
        var b = new SetQueryPageViewModel(qpModel)
        {
            cachedItems = ((PagedResponse<Set>)query["data"]).results
        };
        BindingContext = b;
    }

    private void StatsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var chosenElement = (QueryElement)e.CurrentSelection.FirstOrDefault();
        ((SetQueryPageViewModel)BindingContext).ItemClicked(chosenElement.id);
    }
}