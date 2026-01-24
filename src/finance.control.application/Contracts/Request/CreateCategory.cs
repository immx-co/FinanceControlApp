using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace finance.control.application.Contracts.Request;

public class CreateCategory
{
    [DefaultValue("CategoryName")]
    [Required(ErrorMessage = "Требуется название для категории.")]
    [StringLength(20, ErrorMessage = "Название категории не может быть больше 20 символов.")]
    public required string Name { get; set; }

    public IFormFile? Image { get; set; }
}
