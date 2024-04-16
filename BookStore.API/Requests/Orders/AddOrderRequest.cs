using BookStore.API.Requests.Books;
using System.Diagnostics.CodeAnalysis;

namespace BookStore.API.Requests.Orders
{
    [ExcludeFromCodeCoverage]
    public class AddOrderRequest
    {
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? City { get; set; }
        public IEnumerable<Guid>? Books { get; set; }
    }
}
