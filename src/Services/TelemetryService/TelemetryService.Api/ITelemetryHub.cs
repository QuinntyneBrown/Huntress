namespace TelemetryService.Api;

public interface ITelemetryHub
{
    Task Telemetry(string message);
}
