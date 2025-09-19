using Bogus;
using Microsoft.EntityFrameworkCore;
using PerfPlayground.Domain;

namespace PerfPlayground.Infrastructure
{
   public sealed class DataSeeder
{
    private readonly ILogger<DataSeeder> _log;
    public DataSeeder(ILogger<DataSeeder> log) { _log = log; }

    public async Task SeedIfEmptyAsync(AppDbContext db)
    {
        if (await db.Products.AnyAsync()) return;

        _log.LogInformation("Seeding started...");
        var rnd = new Random();

        var catFaker = new Faker<Category>().RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0]);
        var cats = catFaker.Generate(50);
        await db.Categories.AddRangeAsync(cats);
        await db.SaveChangesAsync();

        var prodFaker = new Faker<Product>()
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(2, 500)))
            .RuleFor(p => p.Stock, f => f.Random.Int(0, 10000))
            .RuleFor(p => p.CategoryId, f => f.PickRandom(cats).Id)
            .RuleFor(p => p.CreatedAt, f => f.Date.PastOffset(2).UtcDateTime);

        var products = prodFaker.Generate(100_000);
        await db.Products.AddRangeAsync(products);
        await db.SaveChangesAsync();

        var custFaker = new Faker<Customer>()
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.FullName, f => f.Name.FullName())
            .RuleFor(c => c.RegisteredAt, f => f.Date.PastOffset(3).UtcDateTime);

        var customers = custFaker.Generate(50_000);
        await db.Customers.AddRangeAsync(customers);
        await db.SaveChangesAsync();

        var orders = new List<Order>(capacity: 500_000);
        var items = new List<OrderItem>(capacity: 1_500_000);

        for (int i = 0; i < 500_000; i++)
        {
            var o = new Order {
                CustomerId = customers[rnd.Next(customers.Count)].Id,
                PlacedAt = DateTime.UtcNow.AddDays(-rnd.Next(0, 365))
            };
            orders.Add(o);
        }
        await db.Orders.AddRangeAsync(orders);
        await db.SaveChangesAsync();

        foreach (var o in orders)
        {
            int itemCount = rnd.Next(1, 6);
            for (int k = 0; k < itemCount; k++)
            {
                var p = products[rnd.Next(products.Count)];
                items.Add(new OrderItem {
                    OrderId = o.Id,
                    ProductId = p.Id,
                    Quantity = rnd.Next(1, 5),
                    UnitPrice = p.Price
                });
            }
        }
        // درج در بچ‌ها برای حافظه:
        const int batch = 50_000;
        for (int i = 0; i < items.Count; i += batch)
            await db.OrderItems.AddRangeAsync(items.Skip(i).Take(batch));

        await db.SaveChangesAsync();
        _log.LogInformation("Seeding finished.");
    }
}
}