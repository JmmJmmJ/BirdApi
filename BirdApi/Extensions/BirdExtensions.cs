using BirdApi.DTOs;
using BirdsApi.Models;

namespace BirdApi.Extensions
{
    public static class BirdExtensions
    {
        public static BirdDto ToDto(this Bird bird)
        {
            if (bird == null)
                return null;

            return new BirdDto
            {
                Id = bird.BirdId,
                Species = bird.Species,
                Binomial_name = bird.Binomial_name,
                Conservation_status = bird.Conservation_status,
                sightingsTotal = bird.Sightings.Count,
            };
        }
    }
}
