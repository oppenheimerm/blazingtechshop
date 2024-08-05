using BT.Core;
using BT.Datastore.EFCore.Interfaces;

namespace BT.UseCases.Categories
{
    public class GetAllCategoriesUseCase : IGetAllCategoriesUseCase
    {
        readonly ICategoryRepository CategoryRepository;

        public GetAllCategoriesUseCase(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public IQueryable<Category> Execute()
        {
            return CategoryRepository.GetAll();
        }
    }
}
