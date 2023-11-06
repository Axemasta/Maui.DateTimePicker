namespace Axemasta.DateTimePicker;

public partial class DateTimePicker : View, IDateTimePicker, IElementConfiguration<DateTimePicker>
{
    /// <summary>Bindable property for <see cref="Date"/>.</summary>
    public readonly static BindableProperty DateProperty = BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(DateTimePicker), default(DateTime), BindingMode.TwoWay,
        coerceValue: CoerceDate,
        propertyChanged: DatePropertyChanged,
        defaultValueCreator: (bindable) => DateTime.Now);
    
    /// <summary>Bindable property for <see cref="MaximumDate"/>.</summary>
    public readonly static BindableProperty MaximumDateProperty = BindableProperty.Create(nameof(MaximumDate), typeof(DateTime), typeof(DateTimePicker), new DateTime(2100, 12, 31),
        validateValue: ValidateMaximumDate, coerceValue: CoerceMaximumDate);
    
    /// <summary>Bindable property for <see cref="MinimumDate"/>.</summary>
    public readonly static BindableProperty MinimumDateProperty = BindableProperty.Create(nameof(MinimumDate), typeof(DateTime), typeof(DateTimePicker), new DateTime(1900, 1, 1),
        validateValue: ValidateMinimumDate, coerceValue: CoerceMinimumDate);
    
    /// <summary>
    /// The Selected Date
    /// </summary>
    public DateTime Date
    {
        get => (DateTime)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }
    
    /// <summary>
    /// The Maximum Date To Be Displayed
    /// </summary>
    public DateTime MaximumDate
    {
        get { return (DateTime)GetValue(MaximumDateProperty); }
        set { SetValue(MaximumDateProperty, value); }
    }

   /// <summary>
   /// The Minimum Date To Be Displayed
   /// </summary>
    public DateTime MinimumDate
    {
        get { return (DateTime)GetValue(MinimumDateProperty); }
        set { SetValue(MinimumDateProperty, value); }
    }
    
    public event EventHandler<DateChangedEventArgs> DateSelected;
    readonly Lazy<PlatformConfigurationRegistry<DateTimePicker>> _platformConfigurationRegistry;

    public DateTimePicker()
    {
        _platformConfigurationRegistry = new Lazy<PlatformConfigurationRegistry<DateTimePicker>>(() => new PlatformConfigurationRegistry<DateTimePicker>(this));
    }
    
    static object CoerceDate(BindableObject bindable, object value)
    {
        var picker = (DateTimePicker)bindable;
        DateTime dateValue = (DateTime)value;

        if (dateValue > picker.MaximumDate)
            dateValue = picker.MaximumDate;

        if (dateValue < picker.MinimumDate)
            dateValue = picker.MinimumDate;

        return dateValue;
    }
    
    static void DatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var datePicker = (DateTimePicker)bindable;
        EventHandler<DateChangedEventArgs> selected = datePicker.DateSelected;

        if (selected != null)
        {
            selected(datePicker, new DateChangedEventArgs((DateTime)oldValue, (DateTime)newValue));
        }
    }
    
    static bool ValidateMaximumDate(BindableObject bindable, object value)
    {
        return ((DateTime)value).Date >= ((DateTimePicker)bindable).MinimumDate.Date;
    }

    static bool ValidateMinimumDate(BindableObject bindable, object value)
    {
        return ((DateTime)value).Date <= ((DateTimePicker)bindable).MaximumDate.Date;
    }
    
    static object CoerceMaximumDate(BindableObject bindable, object value)
    {
        DateTime dateValue = ((DateTime)value).Date;
        var picker = (DateTimePicker)bindable;
        if (picker.Date > dateValue)
            picker.Date = dateValue;

        return dateValue;
    }

    static object CoerceMinimumDate(BindableObject bindable, object value)
    {
        DateTime dateValue = ((DateTime)value).Date;
        var picker = (DateTimePicker)bindable;
        if (picker.Date < dateValue)
            picker.Date = dateValue;

        return dateValue;
    }

    public IPlatformElementConfiguration<T, DateTimePicker> On<T>() where T : IConfigPlatform
    {
        return _platformConfigurationRegistry.Value.On<T>();
    }
}