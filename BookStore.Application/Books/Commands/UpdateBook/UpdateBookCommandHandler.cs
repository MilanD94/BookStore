using BookStore.Application.Metrics;
using BookStore.Data.Books;
using MediatR;

namespace BookStore.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler(IBookRepository bookRepository, BookStoreMetrics meters) : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly BookStoreMetrics _meters = meters;

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var bookToUpdate = await _bookRepository.GetBookById(request.Id) ?? throw new Exception("Book is not found.");
            bookToUpdate.Author = request.Author;
            bookToUpdate.Description = request.Description;
            bookToUpdate.Name = request.Name;
            bookToUpdate.PublishDate = request.PublishDate;
            bookToUpdate.UpdateDate = DateTime.UtcNow;
            bookToUpdate.Value = request.Value;
            bookToUpdate.CategoryId = request.CategoryId;

            await _bookRepository.UpdateBook(bookToUpdate!);
            _meters.UpdateBook();

            return Unit.Value;
        }
    }
}
