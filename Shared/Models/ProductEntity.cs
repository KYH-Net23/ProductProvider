using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string? Model { get; set; }
        public string? Description { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be lower than 0.")]
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string Image { get; set; } = null!;
        public int Stock { get; set; }
        public string? Size { get; set; }
        public DateOnly AddedDate { get; set; }
    }
}