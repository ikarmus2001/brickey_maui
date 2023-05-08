using brickey_maui.Models;
using brickey_maui.ViewModel;

namespace brickey_maui.Pages;

//[QueryProperty(nameof(queryPageModel), "QueryPageModel")]
public partial class QueryPage : ContentPage, IQueryAttributable
{
    //internal QueryPageModel queryPageModel
    //{
    //    set { UnpackBindings(value); }
    //}

    public QueryPage()
	{
		InitializeComponent();
    }

    //private void UnpackBindings(QueryPageModel value)
    //{
    //    if (value != null)
    //    {
            
    //    }
    //}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        BindingContext = new QueryPageViewModel((QueryPageModel)query[nameof(QueryPageModel)]);
    }
}