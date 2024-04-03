using BookStore.Application.Books.Queries.GetAllBooks;
using BookStore.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllBooks")]
        [ProducesResponseType(typeof(List<BookRepresentation>), StatusCodes.Status200OK)]
        public async Task<List<BookRepresentation>> GetAllBooks()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());

            return result;
        }

    }
}
