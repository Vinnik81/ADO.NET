using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NET_2.Models
{
  public class Student
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Coins { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Coins} {UserName} {PasswordHash}";
        }
    }
}
