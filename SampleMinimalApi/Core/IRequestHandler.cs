namespace SampleMinimalApi.Core;

public interface IRequestHandler<TRequestModel, TResponseModel>
    where TRequestModel : IRequestModel
    where TResponseModel : IResponseModel
{
    Task<TResponseModel> HandleAsync(TRequestModel request);
}