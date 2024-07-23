using System.ComponentModel.DataAnnotations;

namespace BTW.Core
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string IconUrl { get; set; } = string.Empty;
        [StringLength(250)]
        public string? Description { get; set; } = string.Empty;

        //public ICollection<Product>? Products { get; set; }
    }
}
