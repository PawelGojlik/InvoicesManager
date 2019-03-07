using Microsoft.AspNet.Identity.EntityFramework;

namespace InvoicesManager.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<InvoicesManager.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<InvoicesManager.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<InvoicesManager.Models.Invoice> Invoices { get; set; }
    }
}