using BirdApi.Models;
using BirdsApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BirdsApi.Data
{
        public class BirdsContext : IdentityDbContext<User>
        {
        public BirdsContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Bird> Birds { get; set; } = null!;

        public DbSet<Sighting> Sighting { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Name = "Member", NormalizedName = "MEMBER" },
                    new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }

                );
        }

    }

}
