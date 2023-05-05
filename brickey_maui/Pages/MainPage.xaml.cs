using viewModel = brickey_maui.ViewModel.MainPageViewModel;

namespace brickey_maui.Pages;


public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void MainPageVM_Loaded(object sender, EventArgs e)
    {
        viewModel.MainPageVM_Loaded();
    }
}

