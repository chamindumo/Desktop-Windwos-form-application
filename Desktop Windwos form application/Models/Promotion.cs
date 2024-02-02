using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_application.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public int promotionId { get; set; }
        public string PayMethod { get; set; }
        public decimal DiscountNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsValid { get; set; }
    }
}
