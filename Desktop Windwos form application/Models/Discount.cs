﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_application.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PaymentMethod { get; set; }
        public decimal DiscountNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsValid { get; set; }
    }
}
