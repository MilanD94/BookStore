namespace BookStore.Models
{
    public class OrderBook : BaseModel
    {
        public Guid Id { get; set; }

        public Guid? OrderId { get; set; }
        public Guid? BookId { get; set; }
    }
}
