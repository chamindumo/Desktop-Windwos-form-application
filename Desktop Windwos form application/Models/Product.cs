using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Desktop_application.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Names { get; set; }

        public string Descriptions { get; set; }

        public decimal Price { get; set; }
        public bool IsAvalable { get; set; }
        public DateTime ExpirDate { get; set; }
        public string ImageData { get; set; }

    }





    public class IdData
    {
        public long Timestamp { get; set; }
        public int Machine { get; set; }
        public int Pid { get; set; }
        public int Increment { get; set; }
        public DateTime CreationTime { get; set; }
    }

}
