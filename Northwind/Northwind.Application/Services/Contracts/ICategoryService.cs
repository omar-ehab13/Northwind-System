namespace Northwind.Application.Services.Contracts
{
    public interface ICategoryService
    {
        Task<bool> IsNameExists(string categoryName);
    }
}