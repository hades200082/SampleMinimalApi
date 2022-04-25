namespace SampleMinimalApi.Core;

public interface IResponseModel{}

public interface IResponseModel<TModel> : IResponseModel
    where TModel : IComparable
{
    TModel Message { get; init; }
    bool Success { get; init; }
}