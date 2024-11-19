using System.ComponentModel.DataAnnotations;

namespace ProductProvider.Models;

public class ProductCategory
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string CategoryName { get; set; } = null!;

    [Required] public ICollection<ProductSize> Sizes { get; set; } = [];
}