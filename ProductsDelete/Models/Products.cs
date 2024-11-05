using System.ComponentModel.DataAnnotations;

namespace ProjectsAPI.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Title { get; set; } = null!;
        //public string? Description { get; set; }
        //public decimal Price { get; set; }
        //public string? Category { get; set; }
        //public string Image { get; set; } = null!;
        //public int Stock { get; set; }
        //public string? Size { get; set; }
        //public int MyProperty { get; set; }
        //public DateOnly AddedDate { get; set; }
    }
}
