using Microsoft.EntityFrameworkCore;
using OverflowingPalette.Domain.Models;
using OverflowingPalette.Domain.Seeds;

namespace OverflowingPalette.Domain.Data
{
    public class OverflowingPaletteDbContext : DbContext
    {
        public OverflowingPaletteDbContext(DbContextOptions options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Level>()
                .HasMany(level => level.InitialBlockStates)
                .WithOne(block => block.Level)
                .HasForeignKey(block => block.LevelId);

            modelBuilder.Entity<Level>()
                .HasMany(level => level.Palette)
                .WithOne(palette => palette.Level)
                .HasForeignKey(palette => palette.LevelId);

            modelBuilder.Entity<BlockState>()
                .HasIndex(block => new { block.LevelId, block.PositionX, block.PositionY })
                .IsUnique();

            SeedsConfiguration.SeedLevelOne(modelBuilder);
            SeedsConfiguration.SeedLevelTwo(modelBuilder);
            SeedsConfiguration.SeedLevelThree(modelBuilder);
        }
    }
}
