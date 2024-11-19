using System.ComponentModel.DataAnnotations;

namespace ProductProvider.Models
{
    public class ProductModel
    {
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? Description { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be lower than 0.")]
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; } = null!;
        public string Image { get; set; } = null!;
        public int Stock { get; set; }
        public ProductSize? Size { get; set; }
        public DateOnly AddedDate { get; set; }
    }
}
