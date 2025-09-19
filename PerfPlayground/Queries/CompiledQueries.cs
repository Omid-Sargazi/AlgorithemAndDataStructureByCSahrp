using Microsoft.EntityFrameworkCore;
using PerfPlayground.DTOs;
using PerfPlayground.Infrastructure;

namespace PerfPlayground.Queries
{
    public static class CompiledQueries
    {
        public static readonly Func<AppDbContext, string?, int?, int, int, IAsyncEnumerable<ProductDto>>
        SearchProducts = EF.CompileAsyncQuery((AppDbContext db, string? term, int? categoryId, int skip, int take) =>
            db.Products.AsNoTracking()
              .Where(p => (term == null || p.Name.Contains(term))
                       && (!categoryId.HasValue || p.CategoryId == categoryId.Value))
              .OrderByDescending(p => p.CreatedAt)
              .Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock, p.Category.Name, p.CreatedAt))
              .Skip(skip).Take(take));
    }
}