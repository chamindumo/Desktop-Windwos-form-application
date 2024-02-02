using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Desktop_Windwos_form_application
{
    public class ItemDetailsDTO
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
    public class PurchaseDetailsDTO
    {
        [Key]

        public int PurchaseId { get; set; }
        public int BatchNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<ItemDetailsDTO> Items { get; set; }

    }
}