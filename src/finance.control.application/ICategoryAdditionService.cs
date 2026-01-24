using finance.control.application.Contracts.Request;
using finance.control.application.Contracts.Response;
using Microsoft.AspNetCore.Hosting;

namespace finance.control.application;

public interface ICategoryAdditionService
{
    Task<Guid> CreateAsync(CreateCategory categoryRequest, IWebHostEnvironment env, CancellationToken ct = default);

    Task<ImageInfo> GetImagePathAsync(Guid categoryId, CancellationToken ct = default);

    Task<List<CategoryInfo>> GetAllCategoryInfos(CancellationToken ct = default);
}
