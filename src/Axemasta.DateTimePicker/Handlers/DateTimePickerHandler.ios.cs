using Axemasta.DateTimePicker.Platforms.iOS;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Handlers;
using UIKit;
namespace Axemasta.DateTimePicker.Handlers;

public partial class DateTimePickerHandler : ViewHandler<IDateTimePicker, MauiDateTimePicker>, IDateTimePickerHandler
{
    internal bool UpdateImmediately { get; set; }
    
    protected override MauiDateTimePicker CreatePlatformView()
    {
        if (!UIDevice.CurrentDevice.CheckSystemVersion(14, 0))
        {
            throw new NotSupportedException("This control is only supported on iOS 14+");
        }
        
        return new MauiDateTimePicker()
        {
            Mode = UIDatePickerMode.DateAndTime,
            PreferredDatePickerStyle = UIDatePickerStyle.Inline,
        };
    }

    protected override void ConnectHandler(MauiDateTimePicker platformView)
    {
        platformView.MauiDateTimePickerDelegate = new DateTimePickerDelegate(this);

        if (VirtualView?.Date is not null && VirtualView.Date is var dt)
        {
            platformView.Date = dt.ToNSDate();
        }
        
        base.ConnectHandler(platformView);
    }

    protected override void DisconnectHandler(MauiDateTimePicker platformView)
    {
        platformView.MauiDateTimePickerDelegate = null;
        
        base.DisconnectHandler(platformView);
    }

    static void OnValueChanged(object? sender)
    {
        if (sender is DateTimePickerHandler datePickerHandler)
        {
            if (datePickerHandler.UpdateImmediately) // Platform Specific
            {
                datePickerHandler.SetVirtualViewDate();
            }

            if (datePickerHandler.VirtualView is not null)
            {
                datePickerHandler.VirtualView.IsFocused = true;
            }
        }
    }

    static void OnStarted(object? sender)
    {
        if (sender is IDateTimePickerHandler datePickerHandler && datePickerHandler.VirtualView is not null)
        {
            datePickerHandler.VirtualView.IsFocused = true;
        }
    }

    static void OnEnded(object? sender)
    {
        if (sender is IDateTimePickerHandler datePickerHandler && datePickerHandler.VirtualView is not null)
        {
            datePickerHandler.VirtualView.IsFocused = false;
        }
    }

    static void OnDoneClicked(object? sender)
    {
        if (sender is DatePickerHandler handler)
        {
            // handler.SetVirtualViewDate();
            handler.PlatformView.ResignFirstResponder();
        }
    }

    void SetVirtualViewDate()
    {
        if (VirtualView is null || PlatformView == null)
        {
            return;
        }
        
        var newDate = PlatformView.Date.ToDateTime();

        VirtualView.Date = newDate;
    }

    class DateTimePickerDelegate : MauiDateTimePickerDelegate
    {
        readonly WeakReference<IDateTimePickerHandler> handler;

        private IDateTimePickerHandler? Handler => handler.TryGetTarget(out IDateTimePickerHandler? target) == true
            ? target
            : null;

        public DateTimePickerDelegate(IDateTimePickerHandler handler)
        {
            this.handler = new WeakReference<IDateTimePickerHandler>(handler);
        }

        public override void DateTimePickerEditingDidBegin()
        {
            OnStarted(Handler);
        }

        public override void DateTimePickerEditingDidEnd()
        {
            OnEnded(Handler);
        }

        public override void DateTimePickerValueChanged()
        {
            OnValueChanged(Handler);
        }

        public override void DoneClicked()
        {
            OnDoneClicked(Handler);
        }
    }
}

