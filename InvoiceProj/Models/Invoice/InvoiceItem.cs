using System;
using System.ComponentModel.DataAnnotations;

namespace InvoiceProj.Models
{
    public class InvoiceItem
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int ItemCode { get; set; }
        [Required]
        [StringLength(140, MinimumLength = 1)]
        public String ItemName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Double Price { get; set; }
    }
}

