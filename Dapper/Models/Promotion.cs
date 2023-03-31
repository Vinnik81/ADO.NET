using System;
using System.Collections.Generic;
using System.Text;

namespace MyDapper.Models
{
   public class Promotion
    {
        public int Id { get; set; }
        public int Percent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CountryId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Country Country { get; set; }
    }
}
