using SampleMinimalApi.Modules.Hello.Interfaces;
using SampleMinimalApi.Modules.Hello.Models;
using SampleMinimalApi.Modules.Hello.RequestHandlers;

namespace SampleMinimalApi.Modules.Hello;

public class HelloModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddSingleton<IHelloBasicNoInputRequestHandler, HelloBasicNoInputRequestHandler>();
        services.AddSingleton<IHelloRequestHandler, HelloRequestHandler>();
        return services;
    }

    public WebApplication MapEndpoints(WebApplication app)
    {
        // GET /hello
        app.MapGet("/hello", async ([FromServices]IHelloBasicNoInputRequestHandler handler) => await handler.HandleAsync());
        
        // GET /hello/{name}
        app.MapGet("/hello/{name}",
            async ([FromServices]IHelloRequestHandler handler, string name) =>
                await handler.HandleAsync(new HelloGetRequestModel { Name = name }));
        
        // POST /hello with body { "name": "..." }
        app.MapPost("/hello",
            async ([FromServices] IHelloRequestHandler handler, [FromBody] HelloGetRequestModel request) =>
                await handler.HandleAsync(request));
        
        return app;
    }
}