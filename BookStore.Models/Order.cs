namespace BookStore.Models
{
    public class Order : BaseModel
    {
        public Guid Id { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? City { get; set; }
        public string? Status { get; set; }
        public virtual List<Book>? Books { get; set; }
        public decimal TotalAmount { get; set; }

        public void SetTotalAmount(decimal amount)
        {
            TotalAmount = amount;
        }

    }
}
