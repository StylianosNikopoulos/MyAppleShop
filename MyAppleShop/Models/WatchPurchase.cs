using System;
using System.ComponentModel.DataAnnotations;

namespace MyAppleShop.Models
{
        public class WatchPurchase
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public int WatchId { get; set; }

            [Required]
            public string UserId { get; set; }

            public DateTime PurchaseDate { get; set; }

            public string UserEmail { get; set; }
    
            public Watch Watch { get; set; }
        }
}

