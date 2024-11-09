namespace domain.Models;

/// <summary>
/// Defines a domain object as being a reading,
/// having occured at a specific Date and Time. 
/// </summary>
public interface IReading
{
    /// <summary>
    /// Gets the date and time of a reading.
    /// </summary>
    public DateTime ReadingTimestamp { get; }
}