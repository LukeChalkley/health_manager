namespace domain.Models.BloodPressure;

/// <summary>
/// Represents the category of a blood pressure reading based on systolic and diastolic values. 
/// </summary>
public class BloodPressureCategory
{
    /// <summary>
    /// Represents the various categories of blood pressure categories. 
    /// </summary>
    public enum Category
    {
        Low, Normal, Elevated, High_Stage1, High_Stage2, HypertensiveCrisis
    }

    public BloodPressureCategory(SystolicValue systolicValue, 
                                 DiastolicValue diastolicValue)
    {
        CalculatedCategory = Calculate(systolicValue, diastolicValue);
    }
    
    /// <summary>
    /// Gets the calculated category of a Blood Pressure reading.
    /// </summary>
    public Category CalculatedCategory { get; }

    /// <summary>
    /// Private helper method to calculate the category of a Blood Pressure reading.
    /// </summary>
    /// <param name="systolicValue">The systolic value of a blood pressure reading.</param>
    /// <param name="diastolicValue">The diastolic reading of a blood pressure reading.</param>
    /// <returns></returns>
    private Category Calculate(SystolicValue systolicValue, DiastolicValue diastolicValue)
    {
        throw new NotImplementedException();
    }
}