using System.Reflection;
using Serilog;

namespace SampleMinimalApi.Core;

public static class ModuleExtensions
{
    static readonly List<IModule> RegisteredModules = new List<IModule>();
    
    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        var modules = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();

        foreach (var module in modules)
        {
            module.RegisterModule(services);
            RegisteredModules.Add(module);
        }
        
        return services;
    }
    
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        app.UseSwagger();
        foreach (var module in RegisteredModules)
        {
            module.MapEndpoints(app);
        }
        app.UseSwaggerUI();
        return app;
    }
    
    public static ConfigureHostBuilder UseLogging(this ConfigureHostBuilder builder, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            builder.UseSerilog((context, c) =>
            {
                c.WriteTo.Console();
                c.WriteTo.Debug();
                c.ReadFrom.Configuration(context.Configuration);
            });
        }
        else
        {
            builder.UseSerilog((context, c) =>
            {
                // TODO: Add your production Serilog configuration here
                c.ReadFrom.Configuration(context.Configuration);
            });
        }
        
        return builder;
    }
}