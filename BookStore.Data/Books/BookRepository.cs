using BookStore.Models;

namespace BookStore.Data.Books
{
    public class BookRepository(ApiDbContext apiDbContext) : IBookRepository
    {
        private readonly ApiDbContext _apiDbContext = apiDbContext;

        public Task<List<Book>> GetAllBooks()
        {
            return Task.Run(() => GetQueryable().ToList());
        }

        public Task<Book> AddBook(Book book)
        {
            var result = _apiDbContext.Books?.Add(book)!;

            _apiDbContext.SaveChangesAsync();

            return Task.Run(() => result.Entity)!;
        }

        public Task<Book> GetBookById(Guid? id)
        {
            var book = _apiDbContext.Books?.FirstOrDefault(x => x.Id == id);

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

        private IQueryable<Book> GetQueryable()
        {
            var books = _apiDbContext.Books;

            return books;
        }
    }
}
