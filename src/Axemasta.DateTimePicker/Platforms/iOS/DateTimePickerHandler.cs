using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;
namespace Axemasta.DateTimePicker.Platforms.iOS;

public class DateTimePickerHandler : ViewHandler<IDateTimePicker, UIDatePicker>,
    IDateTimePickerHandler,
    IViewHandler,
    IElementHandler
{
    public DateTimePickerHandler(IPropertyMapper mapper, CommandMapper commandMapper = null) 
        : base(mapper, commandMapper)
    {
    }

    protected override UIDatePicker CreatePlatformView()
    {
        throw new NotImplementedException();
    }
}
