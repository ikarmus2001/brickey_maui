using brickey_maui.Models;
using brickey_maui.ViewModel;

namespace brickey_maui.Pages;

public partial class QueryPage : ContentPage, IQueryAttributable
{
    public QueryPage()
    {
        InitializeComponent();
    }

    public QueryPage(QueryPageViewModel queryPageVM)
	{
		InitializeComponent();
        BindingContext = queryPageVM;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var qm = (QueryModel)query[nameof(QueryModel)];
        MainImageCarousel.ItemsSource = qm.MainImages;
        QueryTitleLbl.Text = qm.Title;
        StatsCollectionView.ItemsSource = qm.Statistics;
        DescriptionLbl.Text = qm.Description;
    }
}