using BookStore.API.Requests.Categories;
using BookStore.Application.Categories.Commands.AddCategory;
using BookStore.Application.Categories.Commands.DeleteCategory;
using BookStore.Application.Categories.Commands.UpdateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoriesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddCategory(AddCategoryRequest request)
        {
            await _mediator.Send(new AddCategoryCommand
            {
                Name = request.Name
            });

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, UpdateCategoryRequest request)
        {
            await _mediator.Send(new UpdateCategoryCommand
            {
                Id = id,
                Name = request.Name
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteCategoryCommand
            {
                Id = id
            });

            return Ok();
        }
    }
}
