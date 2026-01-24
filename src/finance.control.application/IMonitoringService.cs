namespace finance.control.application;

public interface IMonitoringService
{
    Task MonitorExpiredCategories(CancellationToken ct);
}
