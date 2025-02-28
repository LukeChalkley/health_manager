using System.Reflection;
using domain_model.Contexts;
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
        
        hostBuilder.Services.AddDbContext<HealthManagerContext>(options => options.UseSqlServer(connectionString));
        hostBuilder.Services.AddLogging(options =>
        {
            options.ClearProviders();
            options.AddConsole();
        });
        hostBuilder.Services.AddSingleton<Application>();
        hostBuilder.Services.BuildServiceProvider();
        
        var host = hostBuilder.Build();
        var application = host.Services.GetRequiredService<Application>();
        
        application.Run(hostBuilder.Environment.EnvironmentName);
        
        host.RunAsync();
        

        Console.WriteLine("Press any key to exit...");
    }
}



internal class Application
{
    private readonly ILogger<Application> _logger;
    
    public Application(ILogger<Application> logger)
    {
        this._logger = logger;
    }

    public void Run(string environment)
    {
        _logger.LogInformation($"Application running inside {environment}...REH");
    }
}