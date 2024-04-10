using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Application.Metrics;
using BookStore.Data.Books;
using BookStore.Models;
using MediatR;

namespace BookStore.Application.Books.Commands.AddBook
{
    public class AddBookCommandHandler(IBookRepository bookRepository, BookStoreMetrics meters, IMapper mapper) : IRequestHandler<AddBookCommand, BookRepresentation>
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly BookStoreMetrics _meters = meters;
        private readonly IMapper _mapper = mapper;

        public async Task<BookRepresentation> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Author = request.Author,
                Description = request.Description,
                Name = request.Name,
                CrationDate = DateTime.UtcNow,
                PublishDate = request.PublishDate
            };

            var result = await _bookRepository.AddBook(book);
            _meters.AddBook();
            _meters.IncreaseTotalBooks();

            var response = _mapper.Map<Book, BookRepresentation>(result);

            return response;
        }
    }
}
