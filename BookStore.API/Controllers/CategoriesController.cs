using BookStore.API.Requests.Categories;
using BookStore.Application.Categories.Commands.AddCategory;
using BookStore.Application.Categories.Commands.DeleteCategory;
using BookStore.Application.Categories.Commands.UpdateCategory;
using BookStore.Application.Categories.Queries.GetAllCategories;
using BookStore.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoriesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoryRepresentation>), StatusCodes.Status200OK)]
        public async Task<List<CategoryRepresentation>> GetAllCategories()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());

            return result;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCategory(AddCategoryRequest request)
        {
            await _mediator.Send(new AddCategoryCommand
            {
                Name = request.Name
            });

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
