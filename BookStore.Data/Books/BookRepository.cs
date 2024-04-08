using BookStore.Models;

namespace BookStore.Data.Books
{
    public class BookRepository : IBookRepository
    {

        private readonly ApiDbContext _apiDbContext;

        public BookRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task<List<Book?>> GetAllBooks()
        {
            return await Task.Run(() => GetQueryable().ToList());
        }

        public async Task<Book?> AddBook(Book book)
        {
            var result = _apiDbContext.Books?.Add(book)!;

            await _apiDbContext.SaveChangesAsync();
 
            return result.Entity;
        }

        private IQueryable<Book?> GetQueryable()
        {
            var books = _apiDbContext.Books;

            return books;
        }
    }
}
