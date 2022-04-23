namespace SampleMinimalApi.Core;

public interface IModule
{
    IServiceCollection RegisterModule(IServiceCollection services);
    WebApplication MapEndpoints(WebApplication app);
}