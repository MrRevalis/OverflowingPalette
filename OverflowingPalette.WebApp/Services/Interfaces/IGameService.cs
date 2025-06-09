using OverflowingPalette.Shared.Models;

namespace OverflowingPalette.WebApp.Services.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<string>> GetColorsAsync();
        Task<IEnumerable<AvailableLevels>> GetAvailableLevels();
        Task<LevelDetailsDto> GetGameLevel(int levelNumber);
    }
}
