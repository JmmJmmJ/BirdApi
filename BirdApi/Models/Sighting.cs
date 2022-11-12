using BirdApi.DTOs;
using System;

namespace BirdsApi.Models
{
    public class Sighting
    {
        public int SightingId { get; set; }
        public DateOnly Date { get; set; }
        public string Comment { get; set; }
        public string Place { get; set; }

        public int BirdId { get; set; }
        public Bird Bird { get; set; }
    }
}
