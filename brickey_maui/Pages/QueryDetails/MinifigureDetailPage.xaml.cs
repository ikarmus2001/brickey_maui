using brickey_maui.ViewModel.QueryDetails;
using BrickeyCore.RebrickableModel;

namespace brickey_maui.Pages.QueryDetails;

public partial class MinifigureDetailPage : ContentPage, IQueryAttributable
{
	public MinifigureDetailPage()
	{
		InitializeComponent();
	}

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var b = await MinifigureDetailPageViewModel.Build((Minifigure)query["item"]);
        BindingContext = b;
    }
}