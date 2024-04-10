using BookStore.Application.DTOs;
using MediatR;

namespace BookStore.Application.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<CategoryRepresentation>
    {
        public string? Name { get; set; }

    }
}
