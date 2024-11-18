using ProductProvider.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProductProvider.Models
{
    public class ProductSize
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public SizeType SizeType { get; set; }
        [Required]
        public string Value { get; set; } = null!;

    }
}
