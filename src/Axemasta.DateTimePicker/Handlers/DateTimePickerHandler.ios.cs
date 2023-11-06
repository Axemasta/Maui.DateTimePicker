using System.Diagnostics;
using Foundation;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Handlers;
using UIKit;
namespace Axemasta.DateTimePicker.Handlers;

public partial class DateTimePickerHandler : ViewHandler<IDateTimePicker, UIDatePicker>, IDateTimePickerHandler
{
    internal bool UpdateImmediately { get; set; }
    
    protected override UIDatePicker CreatePlatformView()
    {
        if (!UIDevice.CurrentDevice.CheckSystemVersion(14, 0))
        {
            throw new NotSupportedException("This control is only supported on iOS 14+");
        }
        
        var picker = new MauiDateTimePicker()
        {
            Mode = UIDatePickerMode.DateAndTime,
            PreferredDatePickerStyle = UIDatePickerStyle.Inline,
        };

        return picker;
    }

    protected override void ConnectHandler(UIDatePicker platformView)
    {
        if (platformView is not MauiDateTimePicker platformWrapperView)
        {
            return;
        }

        platformWrapperView.MauiDateTimePickerDelegate = new DateTimePickerDelegate(this);

        if (VirtualView?.Date is not null && VirtualView.Date is var dt)
        {
            platformWrapperView.Date = dt.ToNSDate();
        }
        
        base.ConnectHandler(platformView);
    }

    protected override void DisconnectHandler(UIDatePicker platformView)
    {
        if (platformView is MauiDateTimePicker platformWrapperView)
        {
            platformWrapperView.MauiDateTimePickerDelegate = null;
        }
        
        base.DisconnectHandler(platformView);
    }

    static void OnValueChanged(object? sender)
    {
        Debug.WriteLine("OnValueChanged");
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
            Debug.WriteLine("OnStarted");
            datePickerHandler.VirtualView.IsFocused = true;
        }
    }

    static void OnEnded(object? sender)
    {
        if (sender is IDateTimePickerHandler datePickerHandler && datePickerHandler.VirtualView is not null)
        {
            Debug.WriteLine("OnEnded");
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

internal class MauiDateTimePickerDelegate
{
    public virtual void DateTimePickerEditingDidBegin()
    {

    }

    public virtual void DateTimePickerEditingDidEnd()
    {

    }

    public virtual void DateTimePickerValueChanged()
    {

    }

    public virtual void DoneClicked()
    {

    }
}

internal class MauiDateTimePicker : UIDatePicker
{
    readonly UIDateTimePickerProxy proxy = new();
    
    public MauiDateTimePicker()
    {
        EditingDidBegin += OnEditingDidBegin;
        EditingDidEnd += OnEditingDidEnd;
        ValueChanged += proxy.OnValueChanged;
        
        // TODO: Ensure the accessory view click is not needed...
    }

    private void OnEditingDidBegin(object? sender, EventArgs e)
    {
        MauiDateTimePickerDelegate?.DateTimePickerEditingDidBegin();
    }

    private void OnEditingDidEnd(object? sender, EventArgs e)
    {
        MauiDateTimePickerDelegate?.DateTimePickerEditingDidEnd();
    }
    
    internal MauiDateTimePickerDelegate? MauiDateTimePickerDelegate
    {
        get => proxy.MauiDateTimePickerDelegate;
        set => proxy.MauiDateTimePickerDelegate = value;
    }
    
    class UIDateTimePickerProxy
    {
        internal MauiDateTimePickerDelegate? MauiDateTimePickerDelegate { get; set; }

        public void OnValueChanged(object? sender, EventArgs e) =>
            MauiDateTimePickerDelegate?.DateTimePickerValueChanged();
    }
}