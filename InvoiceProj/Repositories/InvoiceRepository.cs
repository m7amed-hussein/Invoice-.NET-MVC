using InvoiceProj.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace InvoiceProj.Repositories
{
    
    public class InvoiceRepository : IInvoiceRepository<Invoice>
    {
        private readonly InvoiceDbContext _context;
        public InvoiceRepository(InvoiceDbContext context)
        {
            _context = context;
        }
        public void add(Invoice entity)
        {
            _context.Invoices.Add(entity);
            _context.SaveChanges();
        }
        public void delete(Guid id)
        {
            var invoice =  _context.Invoices.Find(id);
            _context.Invoices.Remove(invoice);
            _context.SaveChanges();
        }
        public Invoice find(Guid id)
        {
            return  _context.Invoices.Where(x=>x.Id == id).Include(x => x.Items).AsNoTracking().FirstOrDefault();
        }
        public IList<Invoice> list()
        {
            var invoices = _context.Invoices
            .Include(x => x.Items).AsNoTracking().ToList();
            return  invoices;
        }
        public void update(Guid id, Invoice entity)
        {
            //var invoice = _context.Invoices.Find(id);
            _context.Invoices.Update(entity);
            _context.SaveChanges();
        }
        public List<Invoice> search(string term)
        {
            return _context.Invoices.Where(x => x.CustomerName.Contains(term)).ToList();
        }
    }
}