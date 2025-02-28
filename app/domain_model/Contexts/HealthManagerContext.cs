using domain_model.Entities;
using Microsoft.EntityFrameworkCore;


namespace domain_model.Contexts;

public class HealthManagerContext : DbContext
{
    public HealthManagerContext(DbContextOptions<HealthManagerContext> options) : base(options)
    {
        
    }

    public DbSet<Medication>? Medications { get; set; }
}