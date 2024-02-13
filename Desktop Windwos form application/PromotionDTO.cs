using System;

namespace Desktop_Windwos_form_application
{
    public class PromotionDTO
    {
        public int Id { get; set; }
        public int promotionId { get; set; }
        public string PayMethod { get; set; }
        public decimal DiscountNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsValid { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}