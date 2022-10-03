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
        public void delete(int id)
        {
            var invoice = _context.Invoices.Find(id);
            _context.Invoices.Remove(invoice);
            _context.SaveChanges();
        }
        public Invoice find(int id)
        {
            return _context.Invoices.Find(id);
        }
        public IList<Invoice> list()
        {
            return _context.Invoices.ToList();
        }
        public void update(int id, Invoice entity)
        {
            _context.Invoices.Update(entity);
            _context.SaveChanges();
        }
        public List<Invoice> search(string term)
        {
            return _context.Invoices.Where(x => x.CustomerName.Contains(term)).ToList();
        }
    }
}