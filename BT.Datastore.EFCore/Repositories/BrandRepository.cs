
using BT.Core;
using BT.Datastore.EFCore.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BT.Core.Helpers.Paging;


namespace BT.Datastore.EFCore.Repositories
{
	public class BrandRepository : IBrandRepository
	{
		private readonly ILogger<BrandRepository> Logger;
		private readonly AppDbContext Context;
		private readonly IWebHostEnvironment WebHostEnvironment;

        public BrandRepository(ILogger<BrandRepository> logger, AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
			Logger = logger;
			Context = context;
			WebHostEnvironment = webHostEnvironment;
        }

        public async Task<(Brand brand, bool Success, string ErrorMessage)> Create(Brand brand)
		{
			var brandCodeInUse = await BrandCodeInUseAsync(brand.Code!);
			if (brandCodeInUse)
			{
				var errorMsg = $"Attempted to add product brand with duplicate code: {brand.Code}. Timestamp: {DateTime.UtcNow}";
				Logger.LogError(errorMsg);
				return (new Brand(), false, errorMsg);
			}
			try
			{
				brand.Code = brand.Code!.ToUpperInvariant();
				Context.ProductBrands.Add(brand);
				await Context.SaveChangesAsync();
				Logger.LogInformation($"Brand with Id: {brand.Id}, and name of: {brand.Name} added to database at: {DateTime.UtcNow}");
				return (brand, true, string.Empty);
			}
			catch (Exception ex)
			{
				Logger.LogError($"{ex.ToString()}. Timestamp : {DateTime.UtcNow}");
				return (brand, false, "Bad Request");
			}
		}

		public async Task<(Brand brand, bool Success, string ErrorMessage)> Edit(Brand brand)
		{
			var brandCodeInUse = await BrandCodeInUseAsync(brand.Code!);

			if (brandCodeInUse)
			{
				var errorMsg = $"Attempted to add product brand with duplicate code: {brand.Code}. Timestamp: {DateTime.UtcNow}";
				Logger.LogError(errorMsg);
				return (brand, false, errorMsg);
			}
			try
			{
				brand.Code = brand.Code!.ToUpperInvariant();
				Context.ProductBrands.Update(brand);

				Context.Entry(brand).State = EntityState.Modified;
				await Context.SaveChangesAsync();
				Logger.LogInformation($"Brand with Id: {brand.Id}, and name of: {brand.Name} updated at: {DateTime.UtcNow}");
				return (brand, true, string.Empty);
			}
			catch (Exception ex)
			{
				Logger.LogError($"{ex.ToString()} . Timestamp : {DateTime.UtcNow}");
				return (brand, false, "Bad Request");
			}
		}

		public IQueryable<Brand> GetAllNoPaging()
		{
			var brands = Context.ProductBrands
				.Include(v => v.Products).AsNoTracking();

			return brands;
		}
		
		public PagedList<Brand>GetAll(int? sortingOrder, PagingParameters pagingParameters)
		{
            // Get Enum sort type
            var sortOrder = sortingOrder.HasValue ? PaginHelpers.GetBrandSortOrder(sortingOrder.Value) : BrandSortOrder.Code;

			var brands = Context.ProductBrands
				.Include(p => p.Products).AsNoTracking();

			switch (sortOrder)
			{
				case BrandSortOrder.Id:
					brands = brands.OrderBy(i => i.Id);
						break;
				case BrandSortOrder.Name:
					brands = brands.OrderBy(n => n.Name);
					break;
				case BrandSortOrder.Code:
					brands = brands.OrderBy(c => c.Code);
					break;
				default:
					brands = brands.OrderBy(i => i.Id);
					break;

			}

			return PagedList<Brand>.ToPagedList(brands, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

		public async Task<Brand?> GetBrandById(int id)
		{
			return await Context.ProductBrands
				.Include(p => p.Products)
				.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
		}

		public async Task<bool> BrandCodeInUseAsync(string brandCode)
		{
			// Stored in uppercase.
			var brandCodeToCompare = brandCode.ToUpperInvariant();

			var exist = await Context.ProductBrands
				.Where(b => b.Code == brandCode)
				.AsNoTracking().FirstOrDefaultAsync();


			if (exist != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
