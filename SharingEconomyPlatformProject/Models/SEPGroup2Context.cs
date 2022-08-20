using Microsoft.EntityFrameworkCore;
using SharingEconomyPlatformProject.Models;

namespace SharingEconomyPlatformProject.Models
{
    public class SEPGroup2Context: DbContext
    {
        public SEPGroup2Context()
        {

        }
        public SEPGroup2Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> CustomerM { get; set; }
        public DbSet<Vendor> VendorM { get; set; }
        public DbSet<Admin> AdminM { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Services> services { get; set; }
        public DbSet<BookProduct> bookProducts { get; set; }

        public DbSet<BookService> bookServices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =DESKTOP-QAUICJE;Initial Catalog=SEPGroup2;Integrated Security=true");
        }
        public DbSet<SharingEconomyPlatformProject.Models.CustomerLogin>? CustomerLogin { get; set; }
        public DbSet<SharingEconomyPlatformProject.Models.VendorLogin>? VendorLogin { get; set; }
        public DbSet<SharingEconomyPlatformProject.Models.AdminLogin>? AdminLogin { get; set; }
        public DbSet<SharingEconomyPlatformProject.Models.BookProduct>? BookProduct { get; set; }
    }
}
