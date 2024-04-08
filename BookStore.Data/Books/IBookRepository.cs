using BookStore.Models;

namespace BookStore.Data.Books
{
    public interface IBookRepository
    {
        Task<List<Book?>> GetAllBooks();
        Task<Book?> AddBook(Book book);
    }
}
