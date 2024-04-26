using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Books
{
    public class BookRepository(ApiDbContext apiDbContext) : IBookRepository
    {
        private readonly ApiDbContext _apiDbContext = apiDbContext;

        public Task<List<Book>> GetAllBooks()
        {
            var books = _apiDbContext.Books.Include(x => x.Category)
                                           .ToListAsync();

            return books;
        }

        public Task<Book> AddBook(Book book)
        {
            var result = _apiDbContext.Books?.Add(book)!;

            _apiDbContext.SaveChangesAsync();

            return Task.Run(() => result.Entity)!;
        }

        public Task<Book> GetBookById(Guid? id)
        {
            var book = _apiDbContext.Books?.Include(x => x.Category)
                                           .Where(x => x.Id == id)
                                           .FirstOrDefaultAsync();

            return Task.Run(() => book)!;
        }

        public Task<Book> UpdateBook(Book book)
        {
            var updatedBook = _apiDbContext.Books?.Update(book);
            _apiDbContext.SaveChangesAsync();

            return Task.Run(() => updatedBook!.Entity)!;
        }

        public async Task DeleteBook(Book book)
        {
            _apiDbContext.Books?.Remove(book);
            await _apiDbContext.SaveChangesAsync();
        }
    }
}
