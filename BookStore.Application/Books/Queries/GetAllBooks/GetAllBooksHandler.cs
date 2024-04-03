using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Data.Books;
using MediatR;

namespace BookStore.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookRepresentation>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookRepresentation>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books =  await _bookRepository.GetAllBooks();

            var result = _mapper.Map<List<Models.Book>, List<BookRepresentation>>(books!);

            return result;
        }
    }
}
