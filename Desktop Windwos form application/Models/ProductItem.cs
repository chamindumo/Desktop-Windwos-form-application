using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_application.Models
{
    public class ProductItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string ProductName { get; set; }
    }
}
