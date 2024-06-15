using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bug_Tracker_2024.Data; // Adjust namespace as per your project structure
using System.Threading.Tasks;

namespace Bug_Tracker_2024.Controllers
{
    public class IssuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IssuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Issues
        public async Task<IActionResult> Index()
        {
            var issues = await _context.Issues.ToListAsync();
            return View(issues);
        }

        // Other actions for CRUD operations as needed
    }
}


// using Microsoft.AspNetCore.Mvc;
// using Bug_Tracker_App.Models;
// using System.Collections.Generic;

// using Bug_Tracker_2024.Data;  // Adjust namespace as per your project structure

// namespace Bug_Tracker_2024.Controllers
// {
//     public class IssuesController : Controller
//     {
//         private readonly ApplicationDbContext _context;

//         public IssuesController(ApplicationDbContext context)
//         {
//             _context = context;
//         }

//         // Controller actions here
//     }
// }
