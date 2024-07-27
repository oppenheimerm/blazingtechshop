
using BT.Core;

namespace BT.Datastore.EFCore.Interfaces
{
	public interface IBrandRepository
	{
		Task<(Brand brand, bool Success, string ErrorMessage)> Create(Brand brand);
		Task<(Brand brand, bool Success, string ErrorMessage)> Edit(Brand brand);
		IQueryable<Brand> GetAllNoPaging();
		Task<Brand?> GetBrandById(int id);
	}
}
