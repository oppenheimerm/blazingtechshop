

using System.ComponentModel.DataAnnotations;

namespace BT.Core.ViewModels
{
    public class AddCategory
    {
        [Required]
        [StringLength(25)]
        public string? Name { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string? Code { get; set; }

        [Required]
        public string? Icon { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }
    }
}
