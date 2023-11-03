using System.Diagnostics.CodeAnalysis;
using Android.Content;
using Android.Runtime;
using Android.Util;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Handlers;
namespace Axemasta.DateTimePicker.Handlers;

public partial class DateTimePickerHandler : ViewHandler<IDateTimePicker, MauiDateTimePicker>, IDateTimePickerHandler
{
    protected override MauiDateTimePicker CreatePlatformView()
    {
        throw new NotImplementedException();
    }
}

public class MauiDateTimePicker : AppCompatEditText
{
    protected MauiDateTimePicker(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
    {
    }

    public MauiDateTimePicker([NotNull] Context context) : base(context)
    {
    }

    public MauiDateTimePicker([NotNull] Context context, IAttributeSet attrs) : base(context, attrs)
    {
    }

    public MauiDateTimePicker([NotNull] Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
    {
    }
}