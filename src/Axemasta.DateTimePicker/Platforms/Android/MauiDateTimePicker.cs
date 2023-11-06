using System.Diagnostics.CodeAnalysis;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using TimePicker = Android.Widget.TimePicker;
using AndroidX.AppCompat.Widget;
using Java.Lang;
using Microsoft.Maui.Handlers;
using Boolean = Java.Lang.Boolean;
namespace Axemasta.DateTimePicker.Platforms.Droid;

public class MauiDateTimePicker : LinearLayout
{
    protected MauiDateTimePicker(IntPtr javaReference, JniHandleOwnership transfer) 
        : base(javaReference, transfer)
    {
    }

    public MauiDateTimePicker([NotNull] Context context) 
        : base(context)
    {
        var calendarView = new CalendarView(context);
        calendarView.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);

        var timePicker = new TimePicker(context);
        timePicker.SetIs24HourView(new Boolean(false));

        timePicker.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
        
        // AddView(calendarView);
        AddView(timePicker);
    }

    public MauiDateTimePicker([NotNull] Context context, IAttributeSet attrs) 
        : base(context, attrs)
    {
    }

    public MauiDateTimePicker([NotNull] Context context, IAttributeSet attrs, int defStyleAttr) 
        : base(context, attrs, defStyleAttr)
    {
    }
}