using TelemetryService.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

var app = builder.Build();

app.MapGet("/", () => "Telemetry Api");

app.UseCors("CorsPolicy");

app.MapHub<TelemetryHub>("/hub");

app.Run();