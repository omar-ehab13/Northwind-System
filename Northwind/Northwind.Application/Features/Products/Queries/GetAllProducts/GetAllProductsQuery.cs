﻿using MediatR;
using Northwind.Application.Features.Products.Queries._Helpers.DTOs;
using Northwind.Core.Helpers.Pagination;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : PaginationParameters, IRequest<GenericResponse<List<GetAllProductsDto>>>
    {
        public string? Category { get; set; }
        public string? Supplier { get; set; }
        public decimal MinUnitPrice { get; set; }
        public decimal MaxUnitPrice { get; set; }
    }
}
