using Axemasta.DateTimePicker.Extensions;
using Axemasta.DateTimePicker.Handlers;
namespace Axemasta.DateTimePicker;

public partial class DateTimePicker
{
    internal new static void RemapForControls()
    {
        // Adjust the mappings to preserve Controls.DatePicker legacy behaviors
#if IOS
        DateTimePickerHandler.Mapper.ReplaceMapping<DateTimePicker, IDateTimePickerHandler>(PlatformConfiguration.iOSSpecific.DateTimePicker.UpdateModeProperty.PropertyName, MapUpdateMode);
#endif
    }
}