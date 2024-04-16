namespace BookStore.Models
{
    public class Book : BaseModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public decimal Value { get; set; }
        public Guid? InventoryId { get; set; }
        public Guid? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual List<Order>? Orders { get; set; }
    }
}
