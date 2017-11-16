using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductsController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List(int page = 1)
        {
            return View(
                new ProductsListViewModel
                {
                    Products = repository.Products
                    .OrderBy(p => p.Price)
                .Skip(PageSize * (page - 1))
                .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Products.Count()

                    }
                });
        }
    }
}
        
    
