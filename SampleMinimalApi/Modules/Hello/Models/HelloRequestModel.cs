namespace SampleMinimalApi.Modules.Hello.Models;

public record HelloGetRequestModel : IRequestModel
{
    public string Name { get; init; }
}