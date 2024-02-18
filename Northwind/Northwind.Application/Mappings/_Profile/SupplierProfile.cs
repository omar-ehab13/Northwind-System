using AutoMapper;
using Northwind.Application.Features.ProductsFeature.Suppliers.Commands.AddSupplier;
using Northwind.Application.Features.ProductsFeature.Suppliers.Commands.UpdateSupplier;
using Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetAllSuppliers;
using Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetSupplierById;
using Northwind.Core.Entities;

namespace Northwind.Application.Mappings._Profile
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, GetAllSuppliersDto>().ReverseMap();
            CreateMap<Supplier, GetSupplierByIdDto>().ReverseMap();
            CreateMap<AddSupplierCommand, Supplier>();
            CreateMap<UpdateSupplierCommand, Supplier>();
        }
    }
}
