using BookStore.Models;

namespace BookStore.Data.Categories
{
    public class CategoryRepository(ApiDbContext apiDbContext) : ICategoryRepository
    {
        private readonly ApiDbContext _apiDbContext = apiDbContext;

        public Task<Category> AddCategory(Category category)
        {
            var result = _apiDbContext.Categories?.Add(category)!;

            _apiDbContext.SaveChangesAsync();

            return Task.Run(() => result!.Entity)!;
        }

        public Task<Category> GetCategoryById(Guid? id)
        {
            var category = _apiDbContext.Categories?.FirstOrDefault(x => x.Id == id);

            return Task.Run(() => category)!;
        }

        public Task<Category> UpdateCategory(Category category)
        {
            var result = _apiDbContext.Categories?.Update(category);
            _apiDbContext.SaveChangesAsync();

            return Task.Run(() => result!.Entity)!;
        }

        public async Task DeleteCategory(Category category)
        {
            _apiDbContext.Categories?.Remove(category);
            await _apiDbContext.SaveChangesAsync();
        }
    }
}