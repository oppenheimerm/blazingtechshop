using BT.Core;

namespace BT.UseCases.Brands
{
	public interface IAddBrandUseCase
	{
		/// <summary>
		/// Add a new <see cref="Brand"/> to datastore.
		/// </summary>
		/// <param name="brand"></param>
		/// <returns></returns>
		public Task<(Brand Brand, bool Success, string ErrorMessage)> Add(Brand brand);
	}
}
