namespace domain_model.Entities;

public interface IDomainEntity<TId> where TId : IEquatable<TId>
{
    /// <summary>
    /// Gets the ID of the domain entity object.
    /// </summary>
    TId ID { get; }
}