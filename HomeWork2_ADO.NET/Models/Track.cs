using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork2_ADO.NET.Models
{
   public class Track
    {
        public int id { get; set; }
        public string TrackName { get; set; }
        public TimeSpan TrackTime { get; set; }
        public int idDisk { get; set; }
        public int idStyle { get; set; }
        public int idPerformers { get; set; }
        //public MusicDisk MusicDisk { get; set; }
        //public Style Style { get; set; }
        //public Performers Performers { get; set; }

        public override string ToString()
        {
            return $"{TrackName}, {TrackTime}";
        }
    }
}
