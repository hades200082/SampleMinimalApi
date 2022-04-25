using SampleMinimalApi.Modules.Hello.Interfaces;

namespace SampleMinimalApi.Modules.Hello.RequestHandlers;

public class HelloBasicNoInputRequestHandler : IHelloBasicNoInputRequestHandler
{
    private readonly ILogger<HelloRequestHandler> _logger;

    public HelloBasicNoInputRequestHandler(ILogger<HelloRequestHandler> logger)
    {
        _logger = logger;
    }
    public async Task<SimpleStringResponseModel> HandleAsync()
    {
        _logger.LogDebug("HelloBasicRequestHandler.HandleAsync called");
        try
        {
            return await Task.Run(() => new SimpleStringResponseModel("Hello world!"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "HelloGetRequestHandler.HandleAsync threw an exception");
            return await Task.Run(() => new SimpleStringResponseModel("An error occurred", false));
        }
    }
}