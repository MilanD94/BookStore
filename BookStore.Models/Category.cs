namespace BookStore.Models
{
    public class Category : BaseModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}