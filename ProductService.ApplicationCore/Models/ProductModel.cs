using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.ApplicationCore.Models
{
    public class ProductModel
    {
        public int Id { get; set; } = -1;
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public string ProductImage { get; set; }
        public string SKU { get; set; }
    }
}
