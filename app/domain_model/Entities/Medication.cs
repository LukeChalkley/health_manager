namespace domain_model.Entities;

public class Medication : IDomainEntity<Guid>
{
    /// <summary>
    /// Gets the ID of the Medication object.
    /// </summary>
    public Guid ID { get; }
    
    /// <summary>
    /// Gets the name of the medication object.
    /// </summary>
    public string Name { get; protected set; }
}