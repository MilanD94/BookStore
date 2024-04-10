using BookStore.Application.DTOs;
using MediatR;

namespace BookStore.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }
}
