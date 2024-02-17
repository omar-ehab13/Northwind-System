namespace Northwind.Application.Services.Contracts
{
    public interface ISupplierService
    {
        Task<bool> IsNameExists(string companyName);
    }
}