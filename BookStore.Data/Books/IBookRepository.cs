using BookStore.Models;

namespace BookStore.Data.Books
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> AddBook(Book book);
        Task<Book> GetBookById(Guid? id);
        Task<Book> UpdateBook(Book book);
        Task DeleteBook(Book book);
    }
}
