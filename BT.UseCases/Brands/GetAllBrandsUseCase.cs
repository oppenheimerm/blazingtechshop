
using BT.Core;
using BT.Core.Helpers.Paging;
using BT.Datastore.EFCore.Interfaces;

namespace BT.UseCases.Brands
{
    public class GetAllBrandsUseCase : IGetAllBrandsUseCase
    {
        readonly IBrandRepository BrandRepository;

        public GetAllBrandsUseCase(IBrandRepository brandRepository)
        {
            BrandRepository = brandRepository;
        }

        public PagedList<Brand> Execute(int? sortingOrder, PagingParameters pagingParameters)
        {
            return BrandRepository.GetAll(sortingOrder, pagingParameters);
        }
    }
}
