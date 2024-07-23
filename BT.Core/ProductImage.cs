
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BT.Core
{
    public class ProductImage
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
