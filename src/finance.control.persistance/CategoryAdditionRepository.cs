using finance.control.core;
using finance.control.core.Models;
using Microsoft.EntityFrameworkCore;

namespace finance.control.persistance;

public class CategoryAdditionRepository(ApplicationContext dbContext) : ICategoryAdditionRepository
{
    public async Task<Guid> CreateAsync(Category category, CancellationToken ct)
    {
        await dbContext.Categories.AddAsync(category, ct);
        await dbContext.SaveChangesAsync(ct);
        return category.Id;
    }

    public async Task<string?> GetImagePathAsync(Guid categoryId, CancellationToken ct)
    {
        var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId, ct);
        if (category is not null)
            return category.ImagePath;
        return null;
    }

    public async Task<List<Category>> GetAllAsync(CancellationToken ct)
    {
        return await dbContext.Categories.ToListAsync(ct);
    }

    public async Task<Guid> DeleteByIdAsync(Guid categoryId, CancellationToken ct)
    {
        await dbContext.Categories.Where(c => c.Id == categoryId).ExecuteDeleteAsync();
        return categoryId;
    }
}
