namespace Northwind.Application.Features.Products.Queries._Helpers.DTOs
{
    public record GetAllProductsDto(
        int ProductId,
        string ProductName,
        string? Category,
        string? Supplier,
        decimal? UintPrice);
}
