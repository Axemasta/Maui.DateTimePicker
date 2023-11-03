using Acr.UserDialogs;
using Axemasta.DateTimePicker.Hosting;
using DateTimePickerSample.Pages;
using DateTimePickerSample.ViewModels;
using Microsoft.Extensions.Logging;

namespace DateTimePickerSample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseDateTimePicker()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
        builder.Logging.SetMinimumLevel(LogLevel.Trace);
#endif

        builder.Services.AddTransient<IUserDialogs>(s => UserDialogs.Instance);
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainViewModel>();
        
        return builder.Build();
    }
}