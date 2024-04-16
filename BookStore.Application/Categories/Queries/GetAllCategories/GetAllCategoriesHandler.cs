using AutoMapper;
using BookStore.Application.DTOs;
using BookStore.Data.Categories;
using MediatR;

namespace BookStore.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, List<CategoryRepresentation>>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<CategoryRepresentation>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllCategories();

            var result = _mapper.Map<List<Models.Category>, List<CategoryRepresentation>>(categories!);

            return result;
        }
    }
}
