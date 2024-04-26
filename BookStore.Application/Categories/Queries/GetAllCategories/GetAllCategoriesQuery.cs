using BookStore.Application.DTOs;
using MediatR;

namespace BookStore.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryRepresentation>>
    {
    }
}
