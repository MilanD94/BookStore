using BookStore.Application.DTOs;
using BookStore.Application.Metrics;
using BookStore.Data.Categories;
using MediatR;

namespace BookStore.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, BookStoreMetrics bookStoreMetrics) : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryById(request.Id) ?? throw new Exception("Category is not found.");
            category.UpdateDate = DateTime.UtcNow;
            category.Name = request.Name;

            await _categoryRepository.UpdateCategory(category!);
            bookStoreMetrics.UpdateCategory();

            return Unit.Value;
        }
    }
}
