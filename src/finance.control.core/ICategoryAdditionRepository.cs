using finance.control.core.Models;

namespace finance.control.core;

public interface ICategoryAdditionRepository
{
    Task<Guid> CreateAsync(Category category, CancellationToken ct);

    Task<string?> GetImagePathAsync(Guid categoryId, CancellationToken ct);

    Task<List<Category>> GetAllAsync(CancellationToken ct);

    Task<Guid> DeleteByIdAsync(Guid categoryId, CancellationToken ct);
}
