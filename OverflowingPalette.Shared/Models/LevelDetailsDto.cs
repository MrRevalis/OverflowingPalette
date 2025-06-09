namespace OverflowingPalette.Shared.Models
{
    public record LevelDetailsDto
    {
        public int LevelNumber { get; init; }
        public int MaxMoves { get; init; }
        public int Width { get; init; }
        public int Height { get; init; }
        public string TargetColor { get; init; }
        public List<PaletteColorDto> Palette { get; init; } = new();
        public List<BlockStateDto> InitialState { get; init; } = new();
    }
}
