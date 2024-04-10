using BookStore.Application.DTOs;
using BookStore.Application.Metrics;
using BookStore.Data.Categories;
using MediatR;

namespace BookStore.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, BookStoreMetrics meters) : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly BookStoreMetrics _meters = meters;

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryById(request.Id) ?? throw new Exception("Category is not found.");
            category.UpdateDate = DateTime.UtcNow;
            category.Name = request.Name;

            await _categoryRepository.UpdateCategory(category!);
            _meters.UpdateCategory();

            return Unit.Value;
        }
    }
}
