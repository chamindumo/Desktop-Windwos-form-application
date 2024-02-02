using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Windwos_form_application
{
    public class AvalableStock
    {
        public int Id { get; set; }

        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int StockQuantity { get; set; }
        public string ProductName { get; set; }
    }
}
