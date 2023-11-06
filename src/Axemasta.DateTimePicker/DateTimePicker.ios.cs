using Axemasta.DateTimePicker.Handlers;
using Axemasta.DateTimePicker.PlatformConfiguration.iOSSpecific;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Microsoft.Maui.Controls.Platform;
namespace Axemasta.DateTimePicker;

public partial class DateTimePicker
{
    public static void MapUpdateMode(IDateTimePickerHandler handler, DateTimePicker dateTimePicker)
    {
        if (handler is DateTimePickerHandler dph)
        {
            dph.UpdateImmediately = dateTimePicker.OnThisPlatform().UpdateMode() == UpdateMode.Immediately;
        }
    }

    public static void MapUpdateMode(DateTimePickerHandler handler, DateTimePicker dateTimePicker) =>
        MapUpdateMode((IDateTimePickerHandler)handler, dateTimePicker);
}