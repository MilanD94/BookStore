namespace BookStore.Application.DTOs
{
    public class BookRepresentation
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
