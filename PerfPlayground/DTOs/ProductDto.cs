namespace PerfPlayground.DTOs
{
    public sealed record ProductDto(int Id, string Name, decimal Price, int Stock, string Category, DateTime CreatedAt);
}