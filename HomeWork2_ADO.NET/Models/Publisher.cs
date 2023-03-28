using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork2_ADO.NET.Models
{
   public class Publisher
    {
        public int id { get; set; }
        public string PublisherName { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{PublisherName}, {Country}";
        }
    }
}
