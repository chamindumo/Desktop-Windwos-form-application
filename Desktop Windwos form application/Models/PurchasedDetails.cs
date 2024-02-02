using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_application.Models
{
    public class ItemDetails
    {
        [Key]
        public int ItemId { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal ItemPrice { get; set; }
        public decimal ItemSellPrice { get; set; }
        public int Quantity { get; set; }

    }

    // PurchaseDetails model
    public class PurchaseDetails
    {
        [Key]

        public int PurchaseId { get; set; }
        public int BatchNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<ItemDetails> Items { get; set; }

    }
}
