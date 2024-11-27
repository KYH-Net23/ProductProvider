using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductProvider.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Product name is required")]
        [MinLength(3, ErrorMessage = "Product name must be at least 3 characters long")]
        public string Brand { get; set; } = null!;
        [Required]
        [MinLength(3, ErrorMessage = "Brand name must be at least 3 characters long")]
        public string Model { get; set; } = null!;
        [Required]
        [MinLength(3, ErrorMessage = "Description must be at least 3 characters long")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be lower than 0.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Category name has to be Clothing, Shoes or Electronics.")]
        public string Category { get; set; } = null!;
        [Required]
        [Url]
        public string Image { get; set; } = null!;
        [JsonIgnore]
        public DateOnly AddedDate { get; set; }
    }
}
