using SampleMinimalApi.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterModules();

var app = builder.Build();
app.MapEndpoints();

app.Run();