using System;

namespace BirdsApi.Models
{
    public class Sighting
    {
        public int SightingId { get; set; }
        public String Date { get; set; }
        public String Comment { get; set; }
        public String Place { get; set; }

        public int BirdId { get; set; }
    }
}
