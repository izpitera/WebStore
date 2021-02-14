using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductData _ProductData;

        public BrandsViewComponent(IProductData ProductData) => _ProductData = ProductData;
        public IViewComponentResult Invoke() => View(GetBrands());

        private IEnumerable<BrandsViewModel> GetBrands() =>
            _ProductData.GetBrands().OrderBy(brand => brand.Order).Select(brand => new BrandsViewModel
            {
                Id = brand.Id,
                Name = brand.Name,
                ProductsCount = brand.Products.Count() // use method Count() not field Count of Products!!! Count() sends query to db 
            });
    }
}
