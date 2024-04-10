using System.Diagnostics.CodeAnalysis;

namespace BookStore.API.Requests.Categories
{
    [ExcludeFromCodeCoverage]
    public class AddCategoryRequest
    {
        public string? Name { get; set; }
    }
}
