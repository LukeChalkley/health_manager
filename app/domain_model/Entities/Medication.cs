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
    /// Gets the drug name of the medication object.
    /// </summary>
    public string DrugName { get; protected set; }
    
    /// <summary>
    /// Gets the drug name of the medication object. Optional.
    /// </summary>
    public string BrandName { get; protected set; }
}