using System.Diagnostics.CodeAnalysis;

namespace BookStore.API.Requests.Categories
{
    [ExcludeFromCodeCoverage]
    public class UpdateCategoryRequest
    {
        public string? Name { get; set; }
    }
}
