using System.ComponentModel.DataAnnotations;

namespace ProductProvider.Models;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "Product name must be between 2 and 200 characters.")]
    public string BrandName { get; set; } = null!;
    [Required]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "Product name must be between 2 and 200 characters.")]
    public string ModelName { get; set; } = null!;
    [StringLength(1000)]
    public string? Description { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "Price cannot be lower than 0.")]
    [Required]
    public decimal Price { get; set; }
    public ProductCategory Category { get; set; } = null!;
    [Required]
    [Url]
    [MaxLength(400)]
    public string Image { get; set; } = null!;
    public DateOnly AddedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}