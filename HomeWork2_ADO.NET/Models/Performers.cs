using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork2_ADO.NET.Models
{
    public class Performers
    {
        public int id { get; set; }
        public string PerformersName { get; set; }

        public override string ToString()
        {
            return $"{PerformersName}";
        }
    }
}
