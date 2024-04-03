namespace BookStore.Models
{
    public class Inventory : BaseModel
    {
        public Guid Id { get; set; }
        public string? Amount { get; set; }
    }
}
