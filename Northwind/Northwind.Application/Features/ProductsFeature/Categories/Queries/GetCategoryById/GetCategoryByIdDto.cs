namespace Northwind.Application.Features.ProductsFeature.Categories.Queries.GetCategoryById
{
    public record GetCategoryByIdDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }
    }
}
