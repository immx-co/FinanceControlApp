using finance.control.application;
using finance.control.application.Contracts.Request;
using Microsoft.AspNetCore.Mvc;

namespace finance.control.web.api.Controllers;

[ApiController]
[Route("api/v1/categoryAddition")]
public class CategoryAdditionController : Controller
{
    private readonly ICategoryAdditionService _categoryAdditionService;

    private readonly IWebHostEnvironment _env;

    #region .ctor

    public CategoryAdditionController(
        ICategoryAdditionService categoryAdditionService,
        IWebHostEnvironment env)
    {
        _categoryAdditionService = categoryAdditionService;
        _env = env;
    }

    #endregion

    #region Endpoints

    [HttpPost("create")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create([FromForm] CreateCategory categoryRequest)
    {
        try
        {
            var result = await _categoryAdditionService.CreateAsync(categoryRequest, _env);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{categoryId:guid}/image")]
    [Produces("image/jpeg", "image/png", "image/webp", "image/gif")]
    [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetImage(Guid categoryId)
    {
        try
        {
            var imageInfo = await _categoryAdditionService.GetImagePathAsync(categoryId);
            return PhysicalFile(imageInfo.ImagePath, imageInfo.ContentType);
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("gelAll")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var allCategoryInfos = await _categoryAdditionService.GetAllCategoryInfos();
            return Ok(allCategoryInfos);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    #endregion
}
