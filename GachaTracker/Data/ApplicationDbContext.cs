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

        public DbSet<GenshinCharacter> GenshinCharacters { get; set; }
        public DbSet<StarRailCharacter> StarRailCharacters { get; set; }
        public DbSet<ZZZCharacter> ZZZCharacters { get; set; }
        public DbSet<WutheringCharacter> WutheringCharacters { get; set; }
        public DbSet<EndfieldCharacter> EndfieldCharacters { get; set; } // NEW

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure any specific entity configurations here if needed
            modelBuilder.Entity<EndfieldCharacter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ElementType).IsRequired();
                entity.Property(e => e.SubClass).IsRequired();
                entity.Property(e => e.WeaponType).IsRequired();
            });
        }
    }
}
