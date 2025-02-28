using System.Reflection;
using domain_model.Contexts;
using domain_model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


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
        });
        
        hostBuilder.Services.AddSingleton<Application>();
        hostBuilder.Services.BuildServiceProvider();
        
        var host = hostBuilder.Build();
        var application = host.Services.GetRequiredService<Application>();
        
        host.RunAsync();
        
        Console.WriteLine("Please enter a command: ");
        string command = Console.ReadLine();
        
        application.Run(command);
    }
}



internal class Application
{
    private readonly ILogger<Application> _logger;
    
    private readonly HealthManagerContext _context;
    
    public Application(ILogger<Application> logger, HealthManagerContext context)
    {
        this._logger = logger;
        _context = context;
    }

    public void Run(string command)
    {
        
    }
}