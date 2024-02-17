namespace Northwind.Application.Features.ProductsFeature.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }
    }
}
