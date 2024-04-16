using BookStore.Application.DTOs;
using MediatR;

namespace BookStore.Application.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<Unit>
    {
        public string? Name { get; set; }

    }
}
