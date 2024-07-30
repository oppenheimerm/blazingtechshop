
using System.ComponentModel.DataAnnotations;

namespace BT.Core
{
    public class Brand
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(25)]
        public string? Name { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string? Code { get; set; }        

        public ICollection<Product>? Products { get; set; }
    }
}
