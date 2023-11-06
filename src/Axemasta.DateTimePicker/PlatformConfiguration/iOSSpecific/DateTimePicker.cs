using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
namespace Axemasta.DateTimePicker.PlatformConfiguration.iOSSpecific;

using VirtualView = Axemasta.DateTimePicker.DateTimePicker;

public static class DateTimePicker
{
    /// <summary>Bindable property for <see cref="UpdateMode"/>.</summary>
    public static readonly BindableProperty UpdateModeProperty = BindableProperty.Create(
        nameof(UpdateMode),
        typeof(UpdateMode),
        typeof(VirtualView),
        default(UpdateMode));
    
    public static UpdateMode GetUpdateMode(BindableObject element)
    {
        return (UpdateMode)element.GetValue(UpdateModeProperty);
    }
    
    public static void SetUpdateMode(BindableObject element, UpdateMode value)
    {
        element.SetValue(UpdateModeProperty, value);
    }
    
    public static UpdateMode UpdateMode(this IPlatformElementConfiguration<iOS, VirtualView> config)
    {
        return GetUpdateMode(config.Element);
    }
    
    public static IPlatformElementConfiguration<iOS, VirtualView> SetUpdateMode(this IPlatformElementConfiguration<iOS, VirtualView> config, UpdateMode value)
    {
        SetUpdateMode(config.Element, value);
        return config;
    }
}