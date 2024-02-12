using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Desktop_Windwos_form_application
{
    public class OrderDTO
    {

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string username { get; set; }
        public List<OrderItemDTO> Items { get; set; }
        public decimal Discount { get; set; }
        public int CardNumber { get; set; }
        public int BankId { get; set; }


    }

    public class OrderItemDTO
    {
        [Key]
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string product_id { get; set; }
        public decimal Discount { get; set; }



    }
}