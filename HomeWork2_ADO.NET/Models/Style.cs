using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork2_ADO.NET.Models
{
   public class Style
    {
        public int id { get; set; }
        public string StyleName { get; set; }

        public override string ToString()
        {
            return $"{StyleName}";
        }
    }
}
