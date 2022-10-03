namespace InvoiceProj.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IInvoiceRepository<Invoice> _invoiceRepository;

    public InvoiceController(ILogger<InvoiceController> logger , IInvoiceRepository<Invoice> invoiceRepository)
    {
        _logger = logger;
        _invoiceRepository = invoiceRepository;
    }
    public ActionResult Index()
        {
            var invoices = _invoiceRepository.list();
            return View(invoices);
        }
    }
}