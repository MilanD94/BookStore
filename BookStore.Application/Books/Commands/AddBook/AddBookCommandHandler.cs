using AutoMapper;
using BookStore.Application.Metrics;
using BookStore.Data.Books;
using BookStore.Models;
using MediatR;

namespace BookStore.Application.Books.Commands.AddBook
{
    public class AddBookCommandHandler(IBookRepository bookRepository, BookStoreMetrics meters, IMapper mapper) : IRequestHandler<AddBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly BookStoreMetrics _meters = meters;
        private readonly IMapper _mapper = mapper;

        public async Task<Unit> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var bookToAdd = new Book
            {
                Author = request.Author,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Name = request.Name,
                Value = request.Value,
                PublishDate = request.PublishDate,
                CrationDate = DateTime.UtcNow
            };

            await _bookRepository.AddBook(bookToAdd);

            AddMetrics();

            return Unit.Value;
        }

        private void AddMetrics()
        {
            _meters.AddBook();
            _meters.IncreaseTotalBooks();
        }
    }
}
