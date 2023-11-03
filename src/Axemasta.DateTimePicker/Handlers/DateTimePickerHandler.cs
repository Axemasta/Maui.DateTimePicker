using Microsoft.Maui.Handlers;

#if IOS && !MACCATALYST
using PlatformView = UIKit.UIDatePicker;
#elif MONOANDROID
using PlatformView = Axemasta.DateTimePicker.Platforms.Droid.MauiDateTimePicker;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif
namespace Axemasta.DateTimePicker.Handlers;

public partial class DateTimePickerHandler : IDateTimePickerHandler
{
    public static IPropertyMapper<IDateTimePicker, IDateTimePickerHandler> Mapper = new PropertyMapper<IDateTimePicker, IDateTimePickerHandler>(ViewHandler.ViewMapper)
    {
    };
    
    public static CommandMapper<IPicker, IDateTimePickerHandler> CommandMapper = new(ViewHandler.ViewCommandMapper)
    {
    };
    
    public DateTimePickerHandler() 
        : base(Mapper, CommandMapper)
    {
    }

    public DateTimePickerHandler(IPropertyMapper? mapper)
        : base(mapper ?? Mapper, CommandMapper)
    {
    }

    public DateTimePickerHandler(IPropertyMapper? mapper, CommandMapper? commandMapper)
        : base(mapper ?? Mapper, commandMapper ?? CommandMapper)
    {
    }
    
    IDateTimePicker IDateTimePickerHandler.VirtualView => VirtualView;

    PlatformView IDateTimePickerHandler.PlatformView => PlatformView;
}