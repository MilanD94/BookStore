using BookStore.Application.Metrics;
using BookStore.Data.Categories;
using BookStore.Models;
using MediatR;

namespace BookStore.Application.Categories.Commands.AddCategory
{
    public class AddCategoryCommandHandler(ICategoryRepository categoryRepository, BookStoreMetrics meters) : IRequestHandler<AddCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly BookStoreMetrics _meters = meters;

        public async Task<Unit> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.AddCategory(
                new Category
                {
                    Name = request.Name,
                    CrationDate = DateTime.UtcNow
                }
                );

            AddMetrics();

            return Unit.Value;
        }

        private void AddMetrics()
        {
            _meters.AddCategory();
            _meters.IncreaseTotalCategories();
        }
    }
}
