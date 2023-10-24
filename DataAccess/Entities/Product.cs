namespace DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public int? Discount { get; set; }

        public bool InStock { get; set; }

        public string? Description { get; set; }

        public Category? Category { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
