using BT.Core;
using BT.Datastore.EFCore.Interfaces;

namespace BT.UseCases.Brands
{
	public class AddBrandUseCase : IAddBrandUseCase
	{
		readonly IBrandRepository BrandRepository;

        public AddBrandUseCase(IBrandRepository brandRepository)
        {
			BrandRepository = brandRepository;
        }

        public async Task<(Brand Brand, bool Success, string ErrorMessage)> Add(Brand brand)
		{
			var response = await BrandRepository.Create(brand);
			return response;
		}
	}
}
