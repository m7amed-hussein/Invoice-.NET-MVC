using Microsoft.EntityFrameworkCore;
using InvoiceProj.Models;

namespace InvoiceProj;


public class InvoiceDbContext : DbContext
{
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceItem> ItemInvoices { get; set; }
    public DbSet<Item> Items { get; set; }
    
    public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options): base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder
        .Entity<Invoice>()
        .HasMany(e => e.Items)
        .WithOne()
        .OnDelete(DeleteBehavior.Cascade);
}
}
