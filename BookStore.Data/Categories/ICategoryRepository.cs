using BookStore.Models;

namespace BookStore.Data.Categories
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(Category category);
        Task<Category> GetCategoryById(Guid? id);

    }
}
