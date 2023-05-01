using brickey_maui.Models;
using brickey_maui.ViewModel;

namespace brickey_maui.Pages;

public partial class QueryPage : ContentPage
{
    public QueryPage(QueryPageViewModel queryPageVM)
	{
		InitializeComponent();
        BindingContext = queryPageVM;
    }
}