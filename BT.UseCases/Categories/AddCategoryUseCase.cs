
using BT.Core;
using BT.Datastore.EFCore.Interfaces;
using BT.Datastore.EFCore.Repositories;

namespace BT.UseCases.Categories
{
	public class AddCategoryUseCase : IAddCategoryUseCase
	{
		readonly ICategoryRepository CategoryRepository;
        public AddCategoryUseCase(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

		public async Task<(Category category, bool Success, string ErrorMessage)> Add(Category category)
		{
			var response = await CategoryRepository.Create(category);
			return response;
		}
	}
}
