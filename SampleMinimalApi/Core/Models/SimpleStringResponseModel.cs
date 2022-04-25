namespace SampleMinimalApi.Core.Models;

public record SimpleStringResponseModel : IResponseModel<string>
{
    public SimpleStringResponseModel(string message, bool success = true)
    {
        Message = message;
        Success = success;
    }

    public string Message { get; init; }
    public bool Success { get; init; }
}