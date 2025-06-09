using OverflowingPalette.Shared.Models;

namespace OverflowingPalette.WebApp.Services
{
    public class GameService(HttpClient httpClient)
    {
        public async Task<IEnumerable<string>> GetColorsAsync()
        {
            var uri = "/api/game/colors";
            var results = await httpClient.GetFromJsonAsync<IEnumerable<string>>(uri);

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
