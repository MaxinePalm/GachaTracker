using Microsoft.EntityFrameworkCore;
using GachaTracker.Models;

namespace GachaTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // New separate DbSets for each game
        public DbSet<GenshinCharacter> GenshinCharacters { get; set; }
        public DbSet<StarRailCharacter> StarRailCharacters { get; set; }
        public DbSet<ZZZCharacter> ZZZCharacters { get; set; }
        public DbSet<WutheringCharacter> WutheringCharacters { get; set; }

    }
}