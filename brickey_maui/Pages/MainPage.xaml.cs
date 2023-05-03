using viewModel = brickey_maui.ViewModel.MainPageViewModel;

namespace brickey_maui.Pages;


public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        await viewModel.MainPageVM_Loaded();
    }

    private async void MyProfileBtn_Clicked(object sender, EventArgs e)
    {
        await viewModel.MyProfileBtn_Clicked();
    }

    private async void CollectionBtn_Clicked(object sender, EventArgs e)
    {
        await viewModel.CollectionBtn_Clicked();
    }

    private async void SearchHistoryBtn_Clicked(object sender, EventArgs e)
    {
        await viewModel.SearchHistoryBtn_Clicked();
    }

    private async void SearchBtn_Clicked(object sender, EventArgs e)
    {
        await viewModel.SearchBtn_Clicked();
    }
}

