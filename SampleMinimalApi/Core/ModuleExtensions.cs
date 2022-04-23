using System.Reflection;

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
}