using BirdApi.DTOs;
using BirdsApi.Models;

namespace BirdApi.Extensions
{
    public static class SightingExtensions
    {
        public static SightingDto ToDto(this Sighting sighting)
        {
            if (sighting == null)
                return null;

            return new SightingDto
            {
                Id = sighting.SightingId,
                Date = sighting.Date,
                Comment = sighting.Comment,
                Place = sighting.Place,
                BirdSpecies = sighting.Bird.Species,
                BirdId = sighting.BirdId
            };
        }
    }
}
