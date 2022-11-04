using global::BirdsApi.Data;
using global::BirdsApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace BirdApi.Migrations
{
        public static class DbInitializer
        {
            public static void Initialize(BirdsContext context)
            {
                if (context.Birds.Any()) return;

            var birds = new List<Bird>
            { 
                new Bird
                { Species = "Eurasian magpie",
                Binomial_name = "Pica pica",
                },
                new Bird
                { Species = "Hooded crow",
                Binomial_name = "Corvus corone cornix",
                }
             };

                context.AddRange(birds);
                context.SaveChanges();

            var sightings = new List<Sighting>
            { 
                new Sighting
                {           
                Date = "12-11-2022",
                Place = "Suomi",
                Comment = "Pihassa",
                BirdId = 1
                },
                new Sighting
                {
                Date = "09-10-2022",
                Place = "Suomi",
                Comment = "Puistossa",
                BirdId = 2
                },
            };

            context.AddRange(sightings);
            context.SaveChanges();
        }
        }

}
