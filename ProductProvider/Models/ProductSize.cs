using System.ComponentModel.DataAnnotations;

namespace ProductProvider.Models;

public class ProductSize
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(20)]
    public string SizeName { get; set; } = null!;

    public ProductCategory Category { get; set; } = null!;
}