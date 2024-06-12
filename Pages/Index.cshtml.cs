using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamsGettersSetters;
using System.Collections.Generic;

namespace Graph_API_Parser.Pages;

public class IndexModel : PageModel
{
    public List<Product> Products { get; set; }

    public void OnGet()
    {
        Products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.00M },
            new Product { Id = 2, Name = "Product 2", Price = 20.00M },
            new Product { Id = 3, Name = "Product 3", Price = 30.00M }
        };
    }
}
