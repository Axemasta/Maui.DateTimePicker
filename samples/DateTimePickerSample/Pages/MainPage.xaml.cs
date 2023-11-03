using DateTimePickerSample.ViewModels;
namespace DateTimePickerSample.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel mainViewModel)
    {
        BindingContext = mainViewModel;
        InitializeComponent();
    }
}