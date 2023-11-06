using Axemasta.DateTimePicker.Handlers;
namespace Axemasta.DateTimePicker.Hosting;

public static class AppBuilderExtensions
{
    public static MauiAppBuilder UseDateTimePicker(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.ConfigureMauiHandlers(handlers =>
        {
            handlers.AddHandler<DateTimePicker, DateTimePickerHandler>();
        });
        
        DateTimePicker.RemapForControls();
        
        return mauiAppBuilder;
    }
}