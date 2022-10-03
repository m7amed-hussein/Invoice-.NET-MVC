using System;
using System.ComponentModel.DataAnnotations;

namespace InvoiceProj.Models
{
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

