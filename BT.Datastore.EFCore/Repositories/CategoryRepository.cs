
using BT.Core;
using BT.Datastore.EFCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BT.Datastore.EFCore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ILogger<CategoryRepository>? Logger;
        private readonly AppDbContext? Context;

        public CategoryRepository(ILogger<CategoryRepository> logger, AppDbContext context)
        {
            Logger = logger;
            Context = context;
        }

        public async Task<(Category category, bool Success, string ErrorMessage)> Create(Category category)
        {
            var categoryCodeInUse = await CategoryCodeInUseAsync(category.Code!);
            if (categoryCodeInUse)
            {
                var errorMsg = $"Attempted to add a category with duplicate code: {category.Code}. Timestamp: {DateTime.UtcNow}";
                Logger.LogError(errorMsg);
                return (new Category(), false, errorMsg);
            }
            try
            {
                category.Code = category.Code!.ToUpperInvariant();
                Context.Categories.Add(category);
                await Context.SaveChangesAsync();
                Logger.LogInformation($"cATEGORY with Id: {category.Id}, and name of: {category.Name} added to database at: {DateTime.UtcNow}");
                return (category, true, string.Empty);
            }
            catch (Exception ex)
            {
                Logger.LogError($"{ex.ToString()}. Timestamp : {DateTime.UtcNow}");
                return (category, false, "Bad Request");
            }
        }


        public async Task<(Category category, bool Success, string ErrorMessage)> Edit(Category category)
        {
            var categoryCodeInUse = await CategoryCodeInUseAsync(category.Code!);

            if (categoryCodeInUse)
            {
                var errorMsg = $"Attempted to edit category with duplicate code: {category.Code}. Timestamp: {DateTime.UtcNow}";
                Logger.LogError(errorMsg);
                return (category, false, errorMsg);
            }
            try
            {
                category.Code = category.Code!.ToUpperInvariant();
                Context.Categories.Update(category);

                Context.Entry(category).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                Logger.LogInformation($"Category with Id: {category.Id}, and name of: {category.Name} updated at: {DateTime.UtcNow}");
                return (category, true, string.Empty);
            }
            catch (Exception ex)
            {
                Logger.LogError($"{ex.ToString()} . Timestamp : {DateTime.UtcNow}");
                return (category, false, "Bad Request");
            }
        }

        public IQueryable<Category> GetAll()
        {
            var categories = Context.Categories
                .Include(v => v.Products).AsNoTracking();

            return categories;
        }


        private async Task<bool> CategoryCodeInUseAsync(string categoryCode)
        {
            // Stored in uppercase.
            var CategoryCodeToCompare = categoryCode.ToUpperInvariant();

            var exist = await Context.Categories
                .Where(c => c.Code == categoryCode)
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
