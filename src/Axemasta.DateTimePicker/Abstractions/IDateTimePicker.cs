namespace Axemasta.DateTimePicker.Abstractions;

public interface IDateTimePicker : IView
{
    /// <summary>
    /// Gets the displayed date.
    /// </summary>
    DateTime Date { get; set; }

    /// <summary>
    /// Gets the minimum DateTime selectable.
    /// </summary>
    DateTime MinimumDate { get; }

    /// <summary>
    /// Gets the maximum DateTime selectable.
    /// </summary>
    DateTime MaximumDate { get; }
}