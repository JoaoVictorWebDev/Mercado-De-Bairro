using Microsoft.EntityFrameworkCore;
using SuperMarket.Core.Entities;
namespace SuperMarket.Data.Contexts
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}