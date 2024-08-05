
using BT.Core;

namespace BT.UseCases.Categories
{
	public interface IAddCategoryUseCase
	{
		/// <summary>
		/// Add a new <see cref="Category"/> to datastore.
		/// </summary>
		/// <param name="category"></param>
		/// <returns></returns>
		public Task<(Category category, bool Success, string ErrorMessage)> Add(Category category);
	}
}
