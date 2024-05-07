using BookStore.Application.Metrics;
using BookStore.Data.Books;
using MediatR;

namespace BookStore.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler(IBookRepository bookRepository, BookStoreMetrics bookStoreMetrics) : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository = bookRepository;

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.GetBookById(request.Id) ?? throw new Exception("Book is not found.");

            await _bookRepository.DeleteBook(result!);
            bookStoreMetrics.DeleteBook();
            bookStoreMetrics.DecreaseTotalBooks();

            return Unit.Value;
        }
    }
}
