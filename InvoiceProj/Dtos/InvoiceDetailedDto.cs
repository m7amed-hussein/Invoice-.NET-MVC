using System;
using System.ComponentModel.DataAnnotations;
using InvoiceProj.Models;
namespace InvoiceProj.Dtos
{
    public class InvoiceDetailedDto
    {
        public Guid Id { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public String CreationDate { get; set; }
        public String CustomerName { get; set; }
        
        public String Description { get; set; }
        
        //TODO : Create InvoiceItemDto
        public List<InvoiceItem> Items { get; set; }
    }
}