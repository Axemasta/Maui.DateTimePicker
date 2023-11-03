using Acr.UserDialogs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
namespace DateTimePickerSample.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ILogger logger;
    private readonly IUserDialogs userDialogs;
    
    [ObservableProperty]
    private DateTime selectedDateTime = DateTime.Now;

    public MainViewModel(
        ILogger<MainViewModel> logger,
        IUserDialogs userDialogs)
    {
        this.logger = logger;
        this.userDialogs = userDialogs;
    }

    [RelayCommand]
    public async Task DisplaySelection()
    {
        logger.LogDebug("Selected time is: {SelectedDateTime}", SelectedDateTime);

        await userDialogs.AlertAsync($"Selected time is: {SelectedDateTime}", "DateTimePicker" , "OK");
    }
}