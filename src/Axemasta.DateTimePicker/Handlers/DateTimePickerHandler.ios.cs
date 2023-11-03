using Foundation;
using Microsoft.Maui.Handlers;
using UIKit;
namespace Axemasta.DateTimePicker.Handlers;

public partial class DateTimePickerHandler : ViewHandler<IDateTimePicker, UIDatePicker>, IDateTimePickerHandler
{
    protected override UIDatePicker CreatePlatformView()
    {
        var picker = new UIDatePicker()
        {
            Mode = UIDatePickerMode.DateAndTime,
            PreferredDatePickerStyle = UIDatePickerStyle.Inline,
        };
        
        // VirtualView.Mi

        return picker;
    }
}