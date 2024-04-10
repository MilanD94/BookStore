using BookStore.Application.Metrics;
using BookStore.Data.Books;
using MediatR;

namespace BookStore.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler(IBookRepository bookRepository, BookStoreMetrics meters) : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly BookStoreMetrics _meters = meters;

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.GetBookById(request.Id) ?? throw new Exception("Book is not found.");

            await _bookRepository.DeleteBook(result!);
            _meters.DeleteBook();
            _meters.DecreaseTotalBooks();

            return Unit.Value;
        }
    }
}
