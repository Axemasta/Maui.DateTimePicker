using Axemasta.DateTimePicker.Platforms.iOS;
using Microsoft.Maui.Handlers;
namespace Axemasta.DateTimePicker;

public partial class DateTimePicker
{
   
    public static void MapUpdateMode(IDateTimePickerHandler handler, DateTimePicker datePicker)
    {
        // if (handler is DatePickerHandler dph)
        //     dph.UpdateImmediately = datePicker.OnThisPlatform().UpdateMode() == UpdateMode.Immediately;
    }

    public static void MapUpdateMode(DateTimePickerHandler handler, DateTimePicker datePicker) =>
        MapUpdateMode((IDateTimePickerHandler)handler, datePicker);
}