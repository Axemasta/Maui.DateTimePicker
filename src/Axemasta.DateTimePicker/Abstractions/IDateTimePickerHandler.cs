#if IOS && !MACCATALYST
using PlatformView = UIKit.UIDatePicker;
#elif MONOANDROID
using PlatformView = Axemasta.DateTimePicker.Platforms.Droid.MauiDateTimePicker;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace Axemasta.DateTimePicker.Abstractions;

public interface IDateTimePickerHandler : IViewHandler
{
    new IDateTimePicker VirtualView { get; }
    
    new PlatformView PlatformView { get; }
}