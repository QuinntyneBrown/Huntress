namespace TelemetryService.Api;

public interface ITelemetryHub
{
    Task Send(string message);
}
