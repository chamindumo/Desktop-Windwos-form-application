using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_application.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string username { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal Discount { get; set; }
        public int CardNumber { get; set; }
        public int BankId { get; set; }


    }

    public class OrderItem
    {
        [Key]
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string product_id { get; set; }
        public decimal Discount { get; set; }



    }
}



