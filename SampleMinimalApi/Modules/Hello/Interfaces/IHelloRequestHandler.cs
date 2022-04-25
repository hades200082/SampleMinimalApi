using SampleMinimalApi.Modules.Hello.Models;

namespace SampleMinimalApi.Modules.Hello.Interfaces;

public interface IHelloRequestHandler : IRequestHandler<HelloGetRequestModel, SimpleStringResponseModel>
{
}