using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork2_ADO.NET.Models
{
   public class MusicDisk
    {
        public int id { get; set; }
        public string DiskName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int idStyle { get; set; }
        public int idPerformer { get; set; }
        public int idPublisher { get; set; }

        public override string ToString()
        {
            return $"{DiskName}, {ReleaseDate}";
        }
    }
}
