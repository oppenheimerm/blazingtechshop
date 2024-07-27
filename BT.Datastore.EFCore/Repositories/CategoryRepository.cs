
using BT.Core;
using BT.Datastore.EFCore.Interfaces;
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

        public Task<(Category category, bool Success, string ErrorMessage)> Create(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<(Category category, bool Success, string ErrorMessage)> Edit(Category category)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
