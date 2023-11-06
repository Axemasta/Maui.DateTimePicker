using Axemasta.DateTimePicker.Handlers;
using UIKit;
namespace Axemasta.DateTimePicker.Platforms.iOS;

public class MauiDateTimePicker : UIDatePicker
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