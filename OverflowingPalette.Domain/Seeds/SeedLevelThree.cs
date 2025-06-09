using Microsoft.EntityFrameworkCore;
using OverflowingPalette.Domain.Models;
using static OverflowingPalette.Shared.Constants.Constants;

namespace OverflowingPalette.Domain.Seeds
{
    public static partial class SeedsConfiguration
    {
        public static void SeedLevelThree(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Level>().HasData(
                new Level
                {
                    Id = 3,
                    LevelNumber = 3,
                    Name = "Colorful Grid",
                    Width = 9,
                    Height = 8,
                    MaxMoves = 8,
                    TargetColor = Colors.Blue
                });

            modelBuilder.Entity<LevelPaletteColor>().HasData(
                new LevelPaletteColor { Id = 9, LevelId = 3, Color = Colors.Blue },
                new LevelPaletteColor { Id = 10, LevelId = 3, Color = Colors.Red },
                new LevelPaletteColor { Id = 11, LevelId = 3, Color = Colors.Yellow },
                new LevelPaletteColor { Id = 12, LevelId = 3, Color = Colors.Teal }
            );

            var blockStates = new List<BlockState>();
            int blockId = 145;

            string[,] layout =
                {
                    { Colors.Red, Colors.Red, Colors.Red, Colors.Teal, Colors.Teal, Colors.Teal, Colors.Yellow, Colors.Yellow, Colors.Yellow },
                    { Colors.Blue, Colors.Blue, Colors.Blue, Colors.Teal, Colors.Teal, Colors.Teal, Colors.Yellow, Colors.Yellow, Colors.Yellow },
                    { Colors.Red, Colors.Red, Colors.Red, Colors.Teal, Colors.Teal, Colors.Teal, Colors.Blue, Colors.Blue, Colors.Blue },
                    { Colors.Yellow, Colors.Yellow, Colors.Yellow, Colors.Red, Colors.Red, Colors.Red, Colors.Blue, Colors.Blue, Colors.Blue },
                    { Colors.Yellow, Colors.Yellow, Colors.Yellow, Colors.Red, Colors.Red, Colors.Red, Colors.Teal, Colors.Teal, Colors.Teal },
                    { Colors.Blue, Colors.Blue, Colors.Blue, Colors.Yellow, Colors.Yellow, Colors.Yellow, Colors.Teal, Colors.Teal, Colors.Teal },
                    { Colors.Blue, Colors.Blue, Colors.Blue, Colors.Red, Colors.Red, Colors.Red, Colors.Yellow, Colors.Yellow, Colors.Yellow },
                    { Colors.Red, Colors.Red, Colors.Red, Colors.Blue, Colors.Blue, Colors.Blue, Colors.Teal, Colors.Teal, Colors.Teal }
                };

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    blockStates.Add(new BlockState
                    {
                        Id = blockId++,
                        LevelId = 3,
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
