using Microsoft.EntityFrameworkCore;
using OverflowingPalette.Domain.Models;
using static OverflowingPalette.Shared.Constants.Constants;

namespace OverflowingPalette.Domain.Seeds
{
    public static class SeedsConfiguration
    {
        public static void SeedLevelOne(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Level>().HasData(
                new Level
                {
                    Id = 1,
                    LevelNumber = 1,
                    Name = "The Four Colors",
                    Width = 9,
                    Height = 8,
                    MaxMoves = 4,
                    TargetColor = Colors.Red,
                }
            );

            modelBuilder.Entity<LevelPaletteColor>().HasData(
                new LevelPaletteColor { Id = 1, LevelId = 1, Color = Colors.Blue },
                new LevelPaletteColor { Id = 2, LevelId = 1, Color = Colors.Red },
                new LevelPaletteColor { Id = 3, LevelId = 1, Color = Colors.Yellow },
                new LevelPaletteColor { Id = 4, LevelId = 1, Color = Colors.Teal }
            );

            var blockStates = new List<BlockState>();
            int blockId = 1;

            string[,] layout = {
                { Colors.Red, Colors.Red, Colors.Yellow, Colors.Blue, Colors.Blue, Colors.Yellow, Colors.Red, Colors.Blue, Colors.Blue },
                { Colors.Red, Colors.Red, Colors.Yellow, Colors.Blue, Colors.Blue, Colors.Yellow, Colors.Red, Colors.Red, Colors.Blue },
                { Colors.Red, Colors.Red, Colors.Yellow, Colors.Blue, Colors.Blue, Colors.Yellow, Colors.Yellow, Colors.Red, Colors.Blue },
                { Colors.Red, Colors.Red, Colors.Yellow, Colors.Blue, Colors.Blue, Colors.Red, Colors.Yellow, Colors.Red, Colors.Blue },
                { Colors.Red, Colors.Blue, Colors.Blue, Colors.Blue, Colors.Blue, Colors.Red, Colors.Yellow, Colors.Red, Colors.Blue },
                { Colors.Red, Colors.Blue, Colors.Yellow, Colors.Red, Colors.Red, Colors.Red, Colors.Yellow, Colors.Red, Colors.Blue },
                { Colors.Red, Colors.Blue, Colors.Yellow, Colors.Red, Colors.Yellow, Colors.Yellow, Colors.Yellow, Colors.Red, Colors.Blue },
                { Colors.Red, Colors.Blue, Colors.Yellow, Colors.Red, Colors.Yellow, Colors.Yellow, Colors.Yellow, Colors.Red, Colors.Blue }
            };

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    blockStates.Add(new BlockState
                    {
                        Id = blockId++,
                        LevelId = 1,
                        PositionX = i,
                        PositionY = j,
                        Color = layout[i, j]
                    });
                }
            }

            modelBuilder.Entity<BlockState>().HasData(blockStates);
        }
    }
}
