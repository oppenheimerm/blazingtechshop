
using BT.Core.Helpers.Paging;
using BT.Core;

namespace BT.UseCases.Brands
{
    public interface IGetAllBrandsUseCase
    {
        PagedList<Brand> Execute(int? sortingOrder, PagingParameters pagingParameters);
    }
}
