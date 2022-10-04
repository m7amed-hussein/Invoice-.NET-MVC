using System;
using System.ComponentModel.DataAnnotations;

namespace InvoiceProj.Models
{
    //Invoice Model is different from InvoiceInvoice since the Item 
    //should be saved and when making a new invoice the items should be added to the invoice
    //as InvoiceItem not an Item since Item can be Edited and the price So the InvoiceItem is a snapshot of the Item
    public class Item
    {
        [Required]
        [Key]
        public int ItemCode { get; set; }
        [Required]
        [StringLength(140 , MinimumLength =3)]
        public String ItemName { get; set; }
        [Required]
        public Double Price { get; set; }
    }
}

