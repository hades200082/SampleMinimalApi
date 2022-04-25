namespace SampleMinimalApi.Core;

public interface INoInputRequestHandler<TResponseModel>
    where TResponseModel : IResponseModel
{
    Task<TResponseModel> HandleAsync();
}