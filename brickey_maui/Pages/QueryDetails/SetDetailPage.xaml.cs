using brickey_maui.ViewModel.QueryDetails;
using BrickeyCore.RebrickableModel;

namespace brickey_maui.Pages.QueryDetails;

public partial class SetDetailPage : ContentPage, IQueryAttributable
{
	public SetDetailPage()
	{
		InitializeComponent();
	}

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        throw new NotImplementedException();
        //var b = await SetDetailPageViewModel.Build((Set)query["item"]);
        //BindingContext = b;
    }
}