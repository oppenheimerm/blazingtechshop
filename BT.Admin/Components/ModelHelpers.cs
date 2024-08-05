using BT.Core;
using BT.Core.ViewModels;

namespace BT.Admin.Components
{
	public static class ModelHelpers
	{
		public static Brand ToBrand(AddBrand vm)
		{
			if (vm == null)
			{
				throw new ArgumentNullException(nameof(vm));
			}
			else
			{
				return new Brand
				{
					Name = vm.Name,
					Code = vm.Code
				};
			}
		}

		public static Category ToCategory(AddCategory vm)
		{
			if (vm == null)
			{
				throw new ArgumentNullException(nameof(vm));
			}
			else
			{
				return new Category
				{
					Name = vm.Name,
					Code = vm.Code,
					Icon = vm.Icon,
					Description = vm.Description
				};
			}
		}

	}
}
