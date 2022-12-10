using BirdApi.Models;
using global::BirdsApi.Data;
using global::BirdsApi.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirdApi.Migrations
{
        public static class DbInitializer
        {
            public static async Task Initialize(BirdsContext context, UserManager<User> userManager)
            {

            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "test",
                    Email = "test@test.com"
                };
                await userManager.CreateAsync(user, "t3stPass#");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };
                await userManager.CreateAsync(admin, "t3stPass#");
                await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });

            }

                if (context.Birds.Any()) return;

            var birds = new List<Bird>
            { 
                new Bird
                { Species = "Harakka",
                Binomial_name = "Pica pica",
                Conservation_status = "LC"
                },
                new Bird
                { Species = "Varis",
                Binomial_name = "Corvus corone cornix",
                Conservation_status = "LC"
                }
             };

                context.AddRange(birds);
                context.SaveChanges();

            var testUser = await userManager.FindByNameAsync("test");

            var sightings = new List<Sighting>
            {
                new Sighting
                {
                OwnerID = testUser.Id,
                Date = new DateOnly(2022, 11, 12),
                Place = "Suomi",
                Comment = "Pihassa",
                BirdId = 1
                },
                new Sighting
                {
                OwnerID = testUser.Id,
                Date = new DateOnly(2022, 10, 9),
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
