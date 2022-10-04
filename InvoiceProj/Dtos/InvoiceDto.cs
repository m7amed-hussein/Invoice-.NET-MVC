using InvoiceProj.Models;
namespace InvoiceProj.Dtos
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public DateOnly CreationDate { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public String CustomerName { get; set; }
        public String Description { get; set; }
        public Double TotalPayment { get; set; }
        public InvoiceDto()
        {
            
        }
    }
}