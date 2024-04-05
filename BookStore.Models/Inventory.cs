namespace BookStore.Models
{
    public class Inventory : BaseModel
    {
        public Guid Id { get; set; }
        public string? Amount { get; set; }

        public virtual List<Book>? Books { get; set; }

    }
}
