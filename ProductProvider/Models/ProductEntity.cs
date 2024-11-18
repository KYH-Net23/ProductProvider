using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ProductProvider.Models
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; } = null!;
        [Required]
        public string Model { get; set; } = null!;
        public string? Description { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be lower than 0.")]
        [Required]
        public decimal Price { get; set; }
        [Required]
        public ProductCategory Category { get; set; }
        [Required]
        public string Image { get; set; } = null!;
        [Required]
        public int Stock { get; set; }
        // foregin key to ProductSize
        public int? SizeId { get; set; }
        [ForeignKey(nameof(SizeId))]
        public ProductSize? Size { get; set; }
        public DateOnly AddedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}