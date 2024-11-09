namespace domain.Models.BloodPressure;

/// <summary>
/// Represents a Blood Pressure reading. 
/// </summary>
public class BloodPressure : IReading
{
    public DateTime ReadingTimestamp { get; }

    /// <summary>
    /// Represents the Diastolic value of a Blood Pressure reading.
    /// </summary>
    public DiastolicValue Diastolic { get; }
    
    /// <summary>
    /// Represents the Systolic value of a Blood Pressure reading.
    /// </summary>
    public SystolicValue Systolic { get; }
    
    
    
    public BloodPressure()
    {
        
    }
}