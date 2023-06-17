using brickey_maui.ViewModel.QueryDetails;
using BrickeyCore.RebrickableModel;

namespace brickey_maui.Pages.QueryDetails;

public partial class PartDetailPage : ContentPage, IQueryAttributable
{
	public PartDetailPage()
	{
		InitializeComponent();
	}

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var b = await PartDetailPageViewModel.Build((Part)query["item"]);
        BindingContext = b;
    }

    private async void SelectableItemsView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var x = (Set)e.CurrentSelection.FirstOrDefault();
        await ((PartDetailPageViewModel)BindingContext).SetClicked(x.Id);
    }
}