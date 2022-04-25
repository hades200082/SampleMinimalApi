using SampleMinimalApi.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLogging(builder.Environment);

builder.Services.RegisterModules();

var app = builder.Build();
app.MapEndpoints();

app.Run();