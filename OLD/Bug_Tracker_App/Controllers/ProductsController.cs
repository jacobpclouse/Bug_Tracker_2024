using Microsoft.AspNetCore.Mvc;
using Bug_Tracker_App.Models;
using System.Collections.Generic;

namespace Bug_Tracker_App.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 1000 },
                new Product { Id = 2, Name = "Phone", Price = 500 }
            };
            
            return View(products);
        }
    }
}
