
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BT.Core
{
    public class TechSpec
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(25)]
        public string? Key { get; set; }

        [Required]
        [StringLength(100)]
        public string? Value { get; set; }


        [Required]
        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        public Product? Product { get; set; }

    }
}
