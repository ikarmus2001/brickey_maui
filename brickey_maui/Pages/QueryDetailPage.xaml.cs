using brickey_maui.ViewModel;
using brickey_maui.Models;

namespace brickey_maui.Pages;


public partial class QueryDetailPage : ContentPage, IQueryAttributable
{
	public QueryDetailPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        BindingContext = new QueryDetailPageViewModel((QueryDetailModel)query[nameof(QueryDetailModel)]);
    }
}