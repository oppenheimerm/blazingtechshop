using BT.Core;

namespace BT.Datastore.EFCore.Interfaces
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Get all categories <see cref="Category"/> as an IQuerable list.
        /// </summary>
        /// <returns></returns>
        IQueryable<Category> GetAll();
        Task<(Category category, bool Success, string ErrorMessage)> Create(Category category);
        Task<(Category category, bool Success, string ErrorMessage)> Edit(Category category);

    }
}
