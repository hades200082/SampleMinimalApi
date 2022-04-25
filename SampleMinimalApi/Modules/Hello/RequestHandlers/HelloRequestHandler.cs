using SampleMinimalApi.Modules.Hello.Interfaces;
using SampleMinimalApi.Modules.Hello.Models;

namespace SampleMinimalApi.Modules.Hello.RequestHandlers;

public class HelloRequestHandler : IHelloRequestHandler
{
    private readonly ILogger<HelloRequestHandler> _logger;

    public HelloRequestHandler(ILogger<HelloRequestHandler> logger)
    {
        _logger = logger;
    }
    
    public async Task<SimpleStringResponseModel> HandleAsync(HelloGetRequestModel request)
    {
        _logger.LogDebug("HelloGetRequestHandler.HandleAsync called with model {@Model}", request);
        try
        {
            Guard.Argument(request, nameof(request)).NotNull();
            Guard.Argument(request.Name, nameof(request.Name)).NotNull().NotEmpty();
            return await Task.Run(() => new SimpleStringResponseModel($"Hello {request.Name}!"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "HelloGetRequestHandler.HandleAsync threw an exception");
            return await Task.Run(() => new SimpleStringResponseModel("An error occurred", false));
        }
    }
}