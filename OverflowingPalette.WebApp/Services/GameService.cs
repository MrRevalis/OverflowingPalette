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

        public IEnumerable<AnimatedSquare> GetAnimatedSquares()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    yield return new AnimatedSquare
                    {
                        PositionX = i,
                        PositionY = j,
                        Color = string.Empty,
                    };
                }
            }
        }
    }
}
