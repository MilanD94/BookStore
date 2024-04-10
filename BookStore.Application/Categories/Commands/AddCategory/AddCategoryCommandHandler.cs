using BookStore.Application.DTOs;
using BookStore.Application.Metrics;
using BookStore.Data.Categories;
using BookStore.Models;
using MediatR;

namespace BookStore.Application.Categories.Commands.AddCategory
{
    public class AddCategoryCommandHandler(ICategoryRepository categoryRepository, BookStoreMetrics meters) : IRequestHandler<AddCategoryCommand, CategoryRepresentation>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly BookStoreMetrics _meters = meters;

        public async Task<CategoryRepresentation> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                CrationDate = DateTime.UtcNow,
            };

            var result = await _categoryRepository.AddCategory(category);
            _meters.AddCategory();
            _meters.IncreaseTotalCategories();

            return new CategoryRepresentation { Name = result.Name };
        }
    }
}
