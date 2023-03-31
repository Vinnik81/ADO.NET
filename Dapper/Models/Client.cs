using System;
using System.Collections.Generic;
using System.Text;

namespace MyDapper.Models
{
   public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBith { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
    }
}
