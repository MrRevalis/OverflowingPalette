using Microsoft.EntityFrameworkCore;
using OverflowingPalette.Domain.Models;
using static OverflowingPalette.Shared.Constants.Constants;

namespace OverflowingPalette.Domain.Seeds
{
    public static partial class SeedsConfiguration
    {
        public static void SeedLevelTwo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Level>().HasData(
                new Level
                {
                    Id = 2,
                    LevelNumber = 2,
                    Name = "Crossroads",
                    Width = 9,
                    Height = 8,
                    MaxMoves = 3,
                    TargetColor = Colors.Blue
                });

            modelBuilder.Entity<LevelPaletteColor>().HasData(
                new LevelPaletteColor { Id = 5, LevelId = 2, Color = Colors.Blue },
                new LevelPaletteColor { Id = 6, LevelId = 2, Color = Colors.Red },
                new LevelPaletteColor { Id = 7, LevelId = 2, Color = Colors.Yellow },
                new LevelPaletteColor { Id = 8, LevelId = 2, Color = Colors.Teal }
            );

            var blockStates = new List<BlockState>();
            int blockId = 73;

            string[,] layout =
                {
                   { Colors.Yellow, Colors.Yellow, Colors.Yellow, Colors.Red, Colors.Red, Colors.Red, Colors.Red, Colors.Blue, Colors.Blue },
                   { Colors.Yellow, Colors.Yellow, Colors.Yellow, Colors.Blue, Colors.Blue, Colors.Blue, Colors.Blue, Colors.Red, Colors.Red },
                   { Colors.Red, Colors.Red, Colors.Red, Colors.Blue, Colors.Blue, Colors.Blue, Colors.Blue, Colors.Red, Colors.Red },
                   { Colors.Blue, Colors.Blue, Colors.Blue, Colors.Red, Colors.Red, Colors.Red, Colors.Red, Colors.Yellow, Colors.Yellow },
                   { Colors.Yellow, Colors.Yellow, Colors.Yellow, Colors.Red, Colors.Red, Colors.Red, Colors.Red, Colors.Yellow, Colors.Yellow },
                   { Colors.Blue, Colors.Blue, Colors.Blue, Colors.Blue, Colors.Blue, Colors.Teal, Colors.Teal, Colors.Teal, Colors.Teal },
                   { Colors.Blue, Colors.Blue, Colors.Blue, Colors.Teal, Colors.Teal, Colors.Teal, Colors.Teal, Colors.Teal, Colors.Teal },
                   { Colors.Blue, Colors.Blue, Colors.Blue, Colors.Teal, Colors.Teal, Colors.Teal, Colors.Teal, Colors.Teal, Colors.Teal }
                };

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    blockStates.Add(new BlockState
                    {
                        Id = blockId++,
                        LevelId = 2,
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
