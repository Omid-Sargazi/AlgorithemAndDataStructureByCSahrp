using Microsoft.EntityFrameworkCore;
using PerfPlayground;
using PerfPlayground.DTOs;
using PerfPlayground.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<StopwatchMetrics>();
builder.Services.AddScoped<DataSeeder>();

var app = builder.Build();

// Database seeding as a startup task
// await using (var scope = app.Services.CreateAsyncScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//     await db.Database.EnsureCreatedAsync();

//     var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
//     await seeder.SeedIfEmptyAsync(db);
// }

// Rest of your configuration
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapGet("/api/products/search-baseline", async (
   AppDbContext db, ILoggerFactory lf, StopwatchMetrics m,
    string? term, int? categoryId, int page = 1, int pageSize = 20) =>
{
    var log = lf.CreateLogger("baseline");
    return await m.MeasureAsync(log, "baseline-search", async () =>
    {
        var q = db.Products
                  .Include(p => p.Category) // سنگین
                  .AsQueryable();

        if (!string.IsNullOrWhiteSpace(term))
            q = q.Where(p => p.Name.Contains(term)); // like %term%

        if (categoryId is not null)
            q = q.Where(p => p.CategoryId == categoryId);

        q = q.OrderByDescending(p => p.CreatedAt); // روی ستون بدون ایندکسِ پوششی

        var items = await q.Skip((page - 1)*pageSize).Take(pageSize)
            .Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock, p.Category.Name, p.CreatedAt))
            .ToListAsync(); // projection دیر انجام می‌شود (بعد از include)
        return Results.Ok(items);
    });
});

app.Run();

