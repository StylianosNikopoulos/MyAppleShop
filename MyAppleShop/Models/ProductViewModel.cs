using System.Collections.Generic;

namespace MyAppleShop.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Watch> Watches { get; set; }
    }
}
