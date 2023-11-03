using Microsoft.Maui.Handlers;
using UIKit;
namespace Axemasta.DateTimePicker.Handlers;

public partial class DateTimePickerHandler : ViewHandler<IDateTimePicker, UIDatePicker>, IDateTimePickerHandler
{
    protected override UIDatePicker CreatePlatformView()
    {
        throw new NotImplementedException();
    }
}