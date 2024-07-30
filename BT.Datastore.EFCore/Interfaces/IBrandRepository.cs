
using BT.Core;
using BT.Core.Helpers.Paging;

namespace BT.Datastore.EFCore.Interfaces
{
	public interface IBrandRepository
	{
		Task<(Brand brand, bool Success, string ErrorMessage)> Create(Brand brand);
		Task<(Brand brand, bool Success, string ErrorMessage)> Edit(Brand brand);
		IQueryable<Brand> GetAllNoPaging();
		PagedList<Brand> GetAll(int? sortingOrder, PagingParameters pagingParameters);

        Task<Brand?> GetBrandById(int id);
	}
}
