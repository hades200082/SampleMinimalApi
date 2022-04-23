using SampleMinimalApi.Core;

namespace SampleMinimalApi.Modules.Hello;

public class HelloModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        return services;
    }

    public WebApplication MapEndpoints(WebApplication app)
    {
        app.MapGet("/hello", () => "Hello world!");
        app.MapGet("/hello/{name}", (string name) => $"Hello {name}!");
        return app;
    }
}