using BirdsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BirdsApi.Data
{
        public class BirdsContext : DbContext
        {
            public BirdsContext(DbContextOptions<BirdsContext> options)
                : base(options)
            {
            }

        public DbSet<Bird> Birds { get; set; } = null!;
        }

}
