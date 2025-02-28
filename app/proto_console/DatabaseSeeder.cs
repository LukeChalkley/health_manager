using domain_model.Contexts;
using domain_model.Entities;
using Microsoft.Extensions.Logging;

namespace proto_console;

public class DatabaseSeeder
{
    private readonly HealthManagerContext _context;
    private readonly ILogger<DatabaseSeeder> _logger;

    public DatabaseSeeder(HealthManagerContext context, ILogger<DatabaseSeeder> logger)
    {
        this._context = context; 
        this._logger = logger;
    }
    
    public void InsertMedicationData()
    {
        _logger.LogInformation("Seeding medication data");
        
        _context.Medications.Add(new Medication("Lisdexamfetamine", "Vyvanse"));
        _context.Medications.Add(new Medication("Paroxetine", "Aropax"));
        _context.Medications.Add(new Medication("Mirtazipine", "Mirtanza"));
        
        _context.SaveChanges();
    }
}