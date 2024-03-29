﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Features.ProductsFeature.Categories.Queries.GetAllCategoriesName;
using Northwind.Application.Features.ProductsFeature.Products.Commands.AddProduct;
using Northwind.Application.Features.ProductsFeature.Products.Commands.UpdateProduct;
using Northwind.Application.Features.ProductsFeature.Products.Queries.GetAllProducts;
using Northwind.Application.Features.ProductsFeature.Products.Queries.GetProductById;
using Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetAllSuppliersNames;
using Northwind.MVC.Base;

namespace Northwind.MVC.Controllers
{
    public class ProductsController : AppBaseController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {

        }

        // GET: ProductsController
        public async Task<IActionResult> Index([FromQuery] GetAllProductsQuery query)
        {
            var response = await _mediator.Send(query);

            var categoriesNamesResponse = await _mediator.Send(new GetAllCategoriesNameQuery());
            var categoriesNames = categoriesNamesResponse.Data;

            var suppliersNamesResponse = await _mediator.Send(new GetAllSuppliersNamesQuery());
            var suppliersNames = suppliersNamesResponse.Data;

            ViewBag.Categories = categoriesNames;
            ViewBag.Suppliers = suppliersNames;

            return View(response);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddProductCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);

                if (response.Succeeded)
                    return RedirectToAction(nameof(Index));

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _mediator.Send(new GetProductByIdQuery(id));

            if (response.Succeeded)
                return View(response.Data);

            return NotFound();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateProductCommand command)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
