namespace PerfPlayground.Domain
{
    public sealed class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

    public sealed class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public sealed class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

    public sealed class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
        public DateTime PlacedAt { get; set; } = DateTime.UtcNow;
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal Total => Items.Sum(i => i.UnitPrice * i.Quantity);
    }

    public sealed class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    
}