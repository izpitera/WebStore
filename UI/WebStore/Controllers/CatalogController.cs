﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebStore.Domain;
using WebStore.Domain.ViewModels;
using WebStore.Interfaces.Services;
using WebStore.Services.Mapping;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _ProductData;

        public CatalogController(IProductData ProductData) => _ProductData = ProductData;

        public IActionResult Index(int? BrandId, int? SectionId)
        {
            var filter = new ProductFilter
            {
                BrandId = BrandId,
                SectionId = SectionId,
            };

            var products = _ProductData.GetProducts(filter);

            return View(new CatalogViewModel
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Products = products
                    .OrderBy(p => p.Order)
                    .FromDTO()
                    .ToView() // mapping see Infrastructure
            });
        }

        public IActionResult Details(int id)
        {
            var product = _ProductData.GetProductById(id);
            return View(product.FromDTO().ToView()); // using mapping, we can add automapper also
        }
    }
}
