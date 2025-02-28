using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace domain_model.Entities;

[PrimaryKey(nameof(ID))]
public class Medication : IDomainEntity<int>
{
    /// <summary>
    /// Gets the ID of the Medication object.
    /// </summary>
    public int ID { get; }
    
    /// <summary>
    /// Gets the name of the medication object.
    /// </summary>
    public string Name { get; protected set; }
}