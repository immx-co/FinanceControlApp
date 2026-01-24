namespace finance.control.core.Models;

public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? ImagePath { get; set; }

    public string? ImageUrl { get; set; }
}
