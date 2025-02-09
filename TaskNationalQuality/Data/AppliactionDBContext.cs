using Microsoft.EntityFrameworkCore;
using TaskNationalQuality.Models;

namespace TaskNationalQuality.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Invoice>? Invoices { get; set; }
        public DbSet<ProductInvoice>? ProductInvoices { get; set; }

    }
}
