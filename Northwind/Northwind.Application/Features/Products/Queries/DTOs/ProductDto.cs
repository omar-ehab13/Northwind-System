namespace Northwind.Application.Features.Products.Queries.DTOs
{
    public record ProductDto(
        int ProductId,
        string ProductName,
        string? Category,
        string? Supplier,
        decimal? UintPrice);
}
