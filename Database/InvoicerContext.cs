using System.Data.Entity;

namespace Database
{
    public class InvoicerContext : DbContext
    {

        public InvoicerContext() : base() 

        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceEntry> InvoiceEntries { get; set; }
        public DbSet<Company> Companies { get; set; }
    }    
}