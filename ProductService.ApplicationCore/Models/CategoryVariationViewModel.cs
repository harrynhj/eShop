using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.ApplicationCore.Models
{
    public class CategoryVariationViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string VariationName { get; set; }
    }
}
