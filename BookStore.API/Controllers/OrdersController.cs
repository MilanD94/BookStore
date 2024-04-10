using AutoMapper;
using BookStore.API.Requests.Orders;
using BookStore.Application.DTOs;
using BookStore.Application.Orders.Commands.AddOrder;
using BookStore.Application.Orders.Commands.UpdateOrder;
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
        public async Task<List<OrderRepresentation>> GetOrdersByBookId([FromRoute] Guid bookId)
        {
            var result = await _mediator.Send(new GetOrderByBookIdQuery()
            {
                Id = bookId
            });

            return result;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddOrder(AddOrderRequest request)
        {
            var command = _mapper.Map<AddOrderRequest, AddOrderCommand>(request);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateOrder([FromRoute] Guid id, UpdateOrderRequest request)
        {
            var command = _mapper.Map<UpdateOrderRequest, UpdateOrderCommand>(request);
            command.Id = id;

            await _mediator.Send(command);

            return Ok();
        }
    }
}