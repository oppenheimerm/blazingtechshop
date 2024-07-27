
using System.ComponentModel.DataAnnotations;

namespace BT.Core.ViewModels
{
	public class AddBrand
	{
		[Required]
		[StringLength(25)]
		public string? Name { get; set; }

		[Required]
		[StringLength(4, MinimumLength = 4, ErrorMessage = "4 Letter code required")]
		public string? Code { get; set; }

		[StringLength(500)]
		public string? About { get; set; }

		[StringLength(25)]
		public string? Logo { get; set; }
	}
}
