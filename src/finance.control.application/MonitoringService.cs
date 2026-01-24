using finance.control.core;

namespace finance.control.application;

public class MonitoringService(ICategoryAdditionRepository categoryAdditionRepository) 
    : IMonitoringService
{
    private int _step = 0;

    private readonly TimeSpan _timespan = TimeSpan.FromDays(365);

    public async Task MonitorExpiredCategories(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            var allCategoryEntities = await categoryAdditionRepository.GetAllAsync(ct);

            foreach (var category in allCategoryEntities)
            {
                var now = DateTime.UtcNow;
                if ((category.CreatedAt + _timespan) > now && (category.CreatedAt + _timespan) < (now + _timespan))
                    continue;
                await categoryAdditionRepository.DeleteByIdAsync(category.Id, ct);
            }

            _step++;
            Console.WriteLine($"Прочекано: {_step}...");

            await Task.Delay(TimeSpan.FromMinutes(30), ct);
        }
    }
}
