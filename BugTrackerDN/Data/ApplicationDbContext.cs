// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using BugTrackerDN.Models;

namespace BugTrackerDN.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }
    }
}