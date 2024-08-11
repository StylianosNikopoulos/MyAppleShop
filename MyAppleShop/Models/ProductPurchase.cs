using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAppleShop.Models
{
    public class ProductPurchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string UserId { get; set; } 

        public DateTime PurchaseDate { get; set; }

        public string UserEmail { get; set; }

        public Product Product { get; set; }
    }
}

