namespace Northwind.Application.Features.ProductsFeature.Products.Queries.GetAllProducts
{
    public record GetAllProductsDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? CategoryName { get; set; }
        public string? SupplierName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
