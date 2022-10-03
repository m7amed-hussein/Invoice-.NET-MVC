using System;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Models
{
    public class Item
    {
        [Required]
        public int ItemCode { get; set; }
        [Required]
        [StringLength(140 , MinimumLength =3)]
        public String ItemName { get; set; }
        [Required]
        public Double Price { get; set; }
    }
}

