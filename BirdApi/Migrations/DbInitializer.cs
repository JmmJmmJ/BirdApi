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
            { new Bird
            { Species = "Eurasian magpie",
            Binomial_name = "Pica Pica",
            },
            new Bird
            { Species = "Hooded crow",
            Binomial_name = "Corvus Corone Cornix",
            }
            };

                foreach (var bird in birds)
                {
                    context.Birds.Add(bird);
                }

                context.SaveChanges();
            }
        }

}
