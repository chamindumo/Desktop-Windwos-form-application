using System;

namespace Desktop_Windwos_form_application
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Names { get; set; }

        public string Descriptions { get; set; }

        public decimal Price { get; set; }
        public bool IsAvalable { get; set; }
        public DateTime ExpirDate { get; set; }
        public string ImageData { get; set; }
    }
}