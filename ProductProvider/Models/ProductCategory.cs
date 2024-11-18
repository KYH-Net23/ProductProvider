using ProductProvider.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProductProvider.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public CategoryName Category { get; set; }
        [Required]
        public SizeType SizeType { get; set; }
    }
}
