using System.Reflection;
using domain_model.Contexts;
using domain_model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using proto_console;


public class Program
{
    public static void Main(string[] args)
    {
        HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);
        
        // Get connection string.
        // Create configuration builder and add user secrets from current project (proto_console)
        var configuration = new ConfigurationBuilder().
            AddUserSecrets(Assembly.GetExecutingAssembly()).
            Build();

        var connectionString = configuration.GetConnectionString("healthmanager");
        
        hostBuilder.Services.AddLogging(options =>
        {
            options.ClearProviders();
            options.AddConsole();
        });
        
        hostBuilder.Services.AddDbContext<HealthManagerContext>(options =>
        {
            options.UseSqlServer(connectionString, 
                con => con.MigrationsAssembly("domain_model_migrations"));
        }, ServiceLifetime.Scoped);
        
        hostBuilder.Services.AddScoped<DatabaseSeeder>();
        hostBuilder.Services.BuildServiceProvider();
        
        var host = hostBuilder.Build();

        host.RunAsync();
        
        // Get seeder:
        using (var scope = host.Services.CreateScope())
        {
            var salesContext = scope.ServiceProvider.GetRequiredService<HealthManagerContext>();
            var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
            
            seeder.InsertMedicationData();
        }
    }
}

