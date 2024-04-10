using AutoMapper;
using BookStore.API.Requests.Books;
using BookStore.Application.Books.Commands.AddBook;
using BookStore.Application.Books.Commands.DeleteBook;
using BookStore.Application.Books.Commands.UpdateBook;
using BookStore.Application.Books.Queries.GetAllBooks;
using BookStore.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(typeof(List<BookRepresentation>), StatusCodes.Status200OK)]
        public async Task<List<BookRepresentation>> GetAllBooks()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());

            return result;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddBook(AddBookRequest request)
        {
            var command = _mapper.Map<AddBookRequest, AddBookCommand>(request);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateBook([FromRoute] Guid id, UpdateBookRequest request)
        {
            var command = _mapper.Map<UpdateBookRequest, UpdateBookCommand>(request);
            command.Id = id;

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteBookCommand
            {
                Id = id
            });

            return Ok();
        }
    }
}
