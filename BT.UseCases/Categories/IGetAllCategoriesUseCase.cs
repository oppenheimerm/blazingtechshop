
using BT.Core;
using BT.Core.Helpers.Paging;

namespace BT.UseCases.Categories
{
    public interface IGetAllCategoriesUseCase
    {
        IQueryable<Category> Execute();
    }
}
