using System;
using System.ComponentModel.DataAnnotations;

namespace InvoiceProj.Models
{
	public class Invoice
	{
        [Required]
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        [Required]
        public PaymentMethodEnum PaymentMethod { get; set; }
        [StringLength(50)]
        public String CustomerName { get; set; }
        [StringLength(50)]
        public String Description { get; set; }
        [Required]
        [MinLength(3)]
        public ICollection<InvoiceItem> Items { get; set; }
    }
}

