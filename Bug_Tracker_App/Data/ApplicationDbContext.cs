using Microsoft.EntityFrameworkCore;
using Bug_Tracker_2024.Models;  // Ensure correct namespace for Issue class

namespace Bug_Tracker_2024.Data  // Adjust namespace as per your project structure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }  // Ensure Issue class is referenced correctly
        // Define other DbSets if needed
    }
}
