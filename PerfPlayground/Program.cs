using Microsoft.EntityFrameworkCore;
using PerfPlayground;
using PerfPlayground.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));


    builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<StopwatchMetrics>(); // ابزار ساده برای اندازه‌گیری
builder.Services.AddScoped<DataSeeder>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); // برای سادگی (در پروژه واقعی: migrations)
    await scope.ServiceProvider.GetRequiredService<DataSeeder>().SeedIfEmptyAsync(db);
}

// Configure the HTTP request pipeline.
app.UseSwagger(); app.UseSwaggerUI();
app.MapGet("/", () => Results.Redirect("/swagger"));



app.Run();

