using viewModel = brickey_maui.ViewModel.MainPageViewModel;

namespace brickey_maui.Pages;


public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new viewModel();
    }

    private void MainPageVM_Loaded(object sender, EventArgs e)
    {
        viewModel.MainPageVM_Loaded();
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        viewModel.MainPageVM_Loaded();
    }

    private void MyProfileBtn_Clicked(object sender, EventArgs e)
    {
        viewModel.MyProfileBtn_Clicked();
    }

    private async void CollectionBtn_Clicked(object sender, EventArgs e)
    {
        await viewModel.CollectionBtn_Clicked();
    }

    private async void SearchHistoryBtn_Clicked(object sender, EventArgs e)
    {
        await viewModel.SearchHistoryBtn_Clicked();
    }

    private void SearchBtn_Clicked(object sender, EventArgs e)
    {
        ((viewModel)BindingContext).SearchBtn_Clicked();
    }
}

