using BookStore.Application.DTOs;
using BookStore.Application.Metrics;
using BookStore.Data.Books;
using BookStore.Models;
using MediatR;

namespace BookStore.Application.Books.Commands
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookRepresentation>
    {
        private readonly IBookRepository _bookRepository;
        private readonly BookStoreMetrics _meters;

        public AddBookCommandHandler(IBookRepository bookRepository, BookStoreMetrics meters)
        {
            _bookRepository = bookRepository;
            _meters = meters;
        }

        public async Task<BookRepresentation> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Author = request.Author,
                Description = request.Description,
                Name = request.Name,
            };

            var result = await _bookRepository.AddBook(book);
            _meters.AddBook();
            _meters.IncreaseTotalBooks();

            return new BookRepresentation { Description = result!.Description };
        }
    }
}
