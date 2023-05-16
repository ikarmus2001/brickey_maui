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
        var b = await SetDetailPageViewModel.Build((Set)query["item"]);
        BindingContext = b;
    }
}