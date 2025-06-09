using OverflowingPalette.Domain.Models.Base;

namespace OverflowingPalette.Domain.Models
{
    public class LevelPaletteColor : IBaseEntity
    {
        public int Id { get; set; }
        public string? Color { get; set; }

        public int LevelId { get; set; }
        public virtual Level Level { get; set; } = null!;
    }
}
