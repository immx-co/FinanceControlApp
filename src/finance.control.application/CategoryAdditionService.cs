using finance.control.application.Contracts.Request;
using finance.control.application.Contracts.Response;
using finance.control.core;
using finance.control.core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;

namespace finance.control.application;

public class CategoryAdditionService(ICategoryAdditionRepository categoryAdditionRepository)
    : ICategoryAdditionService
{
    public async Task<Guid> CreateAsync(
        CreateCategory categoryRequest, 
        IWebHostEnvironment env, 
        CancellationToken ct = default)
    {
        if (categoryRequest.Image is null || categoryRequest.Image.Length <= 0)
            throw new ArgumentException("Не передано изображение для категории.");

        if (!categoryRequest.Image.ContentType.StartsWith("image/"))
            throw new ArgumentException("Передано не изображение.");

        var uploadsDir = Path.Combine(env.WebRootPath, "uploads", "categories");
        Directory.CreateDirectory(uploadsDir);

        var categoryId = Guid.NewGuid();

        var extension = Path.GetExtension(categoryRequest.Image.FileName);
        var fileName = $"{categoryId}{extension}";
        var filePath = Path.Combine(uploadsDir, fileName);

        await using var stream = File.Create(filePath);
        await categoryRequest.Image.CopyToAsync(stream, ct);

        var category = new Category
        {
            Id = categoryId,
            Name = categoryRequest.Name,
            CreatedAt = DateTime.UtcNow,
            ImagePath = filePath,
            ImageUrl = $"/uploads/categories/{fileName}"
        };

        return await categoryAdditionRepository.CreateAsync(category, ct);
    }

    public async Task<ImageInfo> GetImagePathAsync(Guid categoryId, CancellationToken ct = default)
    {
        var imagePath = await categoryAdditionRepository.GetImagePathAsync(categoryId, ct);
        if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            throw new ArgumentException("Не найдена картинка по переданному идентификатору категории.");

        var provider = new FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(imagePath, out var contentType))
            contentType = "application/octet-stream";

        return new ImageInfo(imagePath, contentType);
    }

    public async Task<List<CategoryInfo>> GetAllCategoryInfos(CancellationToken ct = default)
    {
        var allDbCategories = await categoryAdditionRepository.GetAllAsync(ct);
        return allDbCategories.Select(c => new CategoryInfo
        {
            Id = c.Id,
            Name = c.Name,
        }).ToList();
    }
}
