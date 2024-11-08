namespace ProductProvider.Models
{
    public class ProductsModel
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string Image { get; set; } = null!;
        public int Stock { get; set; }
        public string? Size { get; set; }
        public DateOnly AddedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
