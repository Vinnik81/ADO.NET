using System;
using System.Collections.Generic;
using System.Text;

namespace MyDapper.Models
{
   public class InterestedBuyer
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Client Client { get; set; }
    }
}
