using BookStore.Application.Metrics;
using BookStore.Data.Categories;
using MediatR;

namespace BookStore.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, BookStoreMetrics bookStoreMetrics) : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryById(request.Id) ?? throw new Exception("Category is not found.");

            await _categoryRepository.DeleteCategory(category!);
            bookStoreMetrics.DeleteCategory();

            return Unit.Value;
        }
    }
}
