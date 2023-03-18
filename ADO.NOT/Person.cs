using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.NET
{
   public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public override string? ToString()
        {
            return $"{Id}\t{FirstName}\t\t{LastName.ToString().PadRight(10, '_')}\t{Age}";
        }
    }
}
