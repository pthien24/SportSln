using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers 
{ 

    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int  pageSize = 4;
        public HomeController(IStoreRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult Index(string? category,int productPage = 1)
        {
            return View(
                    new ProductListViewModel
                    {
                        Products = repository.Products
                        .Where(p => category == null || p.Category == category)
                        .OrderBy(p => p.ProductId).Skip((productPage - 1) * pageSize).Take(pageSize),
                        PageInfo = new PageInfo
                        {
                            CurrentPage = productPage,
                            ItemPerPage = pageSize,
                            TotalItem = category == null
                                ? repository.Products.Count()
                                : repository.Products.Where(e =>e.Category == category).Count()
                        },
                        CurrentCategory = category
                    }) ;
        }
    }
}