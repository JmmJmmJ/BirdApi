using System;

namespace BirdApi.DTOs
{
    public class SightingDto
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
        public string Place { get; set; }

        public string BirdSpecies { get; set; }
    }
}
