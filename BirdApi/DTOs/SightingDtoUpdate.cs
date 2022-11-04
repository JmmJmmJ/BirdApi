using System;

namespace BirdApi.DTOs
{
    public class SightingDtoCreate
    {
        public string Date { get; set; }
        public string Comment { get; set; }
        public string Place { get; set; }

        public int BirdId { get; set; }
    }
}
