using Microsoft.EntityFrameworkCore;
using Invoice.Models;

namespace Invoice.InvoiceDbContext;


public class InvoiceDbContext : DbContext
{
    public DbSet<Invoice.Models.Invoice> Invoices { get; set; }
    public DbSet<InvoiceItem> ItemInvoices { get; set; }
    public DbSet<Item> Items { get; set; }
    
    public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options): base(options)
    { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
}
