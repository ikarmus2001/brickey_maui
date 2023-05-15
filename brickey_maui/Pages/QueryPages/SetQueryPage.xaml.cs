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
        throw new NotImplementedException();
        //var x = e.CurrentSelection.FirstOrDefault() as QueryElement;
        //((SetQueryPageViewModel)BindingContext).ItemClicked(x.id);
    }
}