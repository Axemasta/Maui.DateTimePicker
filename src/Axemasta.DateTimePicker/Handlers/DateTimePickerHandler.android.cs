using System.Diagnostics.CodeAnalysis;
using Android.Content;
using Android.Runtime;
using Android.Util;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Handlers;
using Axemasta.DateTimePicker.Platforms.Droid;
namespace Axemasta.DateTimePicker.Handlers;

public partial class DateTimePickerHandler : ViewHandler<IDateTimePicker, MauiDateTimePicker>, IDateTimePickerHandler
{
    protected override MauiDateTimePicker CreatePlatformView()
    {
        var picker = new MauiDateTimePicker(Context);
        return picker;
    }
}