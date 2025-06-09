using OverflowingPalette.Domain.Models.Base;

namespace OverflowingPalette.Domain.Models
{
    public class Level : IBaseEntity
    {
        public int Id { get; set; }
        public int LevelNumber { get; set; }
        public string? Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int MaxMoves { get; set; }
        public string? TargetColor { get; set; }

        public virtual ICollection<BlockState> InitialBlockStates { get; set; } = new List<BlockState>();
        public virtual ICollection<LevelPaletteColor> Palette { get; set; } = new List<LevelPaletteColor>();
    }
}
