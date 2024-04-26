using AutoMapper;
using BookStore.API.Requests.Orders;
using BookStore.Application.DTOs;
using BookStore.Application.Orders.Commands.AddOrder;
using BookStore.Application.Orders.Queries.GetAllOrders;
using BookStore.Application.Orders.Queries.GetOrdersByBookId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(typeof(List<OrderRepresentation>), StatusCodes.Status200OK)]
        public async Task<List<OrderRepresentation>> GetAllOrders()
        {
            var result = await _mediator.Send(new GetAllOrdersQuery());

            return result;
        }

        [HttpGet("{bookId}")]
        [ProducesResponseType(typeof(List<OrderRepresentation>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<OrderRepresentation>> GetOrdersByBookId([FromRoute] Guid bookId)
        {
            var result = await _mediator.Send(new GetOrderByBookIdQuery()
            {
                Id = bookId
            });

            return result;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddOrder(AddOrderRequest request)
        {
            var command = _mapper.Map<AddOrderRequest, AddOrderCommand>(request);

            await _mediator.Send(command);

            return Ok();
        }
    }
}