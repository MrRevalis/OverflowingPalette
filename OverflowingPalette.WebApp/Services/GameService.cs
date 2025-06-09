using OverflowingPalette.Shared.Models;
using OverflowingPalette.WebApp.Services.Interfaces;

namespace OverflowingPalette.WebApp.Services
{
    public class GameService(HttpClient httpClient) : IGameService
    {
        public async Task<IEnumerable<string>> GetColorsAsync()
        {
            var uri = "/api/game/colors";
            var results = await httpClient.GetFromJsonAsync<IEnumerable<string>>(uri);

            return results!;
        }

        public async Task<IEnumerable<AvailableLevels>> GetAvailableLevels()
        {
            var uri = $"/api/game/levels";
            var results = await httpClient.GetFromJsonAsync<IEnumerable<AvailableLevels>>(uri);

            return results!;
        }

        public async Task<LevelDetailsDto> GetGameLevel(int levelNumber)
        {
            var uri = $"/api/game/{levelNumber}";
            var results = await httpClient.GetFromJsonAsync<LevelDetailsDto>(uri);

            return results!;
        }
    }
}
