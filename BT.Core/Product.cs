
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BT.Core
{
    public class Product
    {
        public Product()
        {
            TimeStamp = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; } = string.Empty;

        [Required]
        public decimal? BasePrice { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        [ForeignKey("Brand")]
        public int? BrandId { get; set; }

        public Brand? Brand { get; set; }

        public ICollection<ProductImage>? ProductImages { get; set; }

        public ICollection<TechSpec>? Specs {get; set;}

        public DateTime TimeStamp { get; set; }

        public string GetFormattedPrice() => BasePrice!.Value.ToString("0.00");
    }
}
