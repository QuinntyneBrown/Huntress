using TelemetryService.Api;


try
{


    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddApiServices();

    var app = builder.Build();

    app.MapGet("/", () => "Hello World!");

    app.MapHub<TelemetryHub>("/hub");

    app.Run();
}
catch(Exception e)
{
    throw e;
}