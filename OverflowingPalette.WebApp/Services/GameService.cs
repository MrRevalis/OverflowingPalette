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
            var list = new[] {
                "#62b4cf",
                    "#D22B2B",
                    "#FFC300",
                    "#AFE1AF" };

            var rnd = new Random();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    yield return new AnimatedSquare
                    {
                        PositionX = i,
                        PositionY = j,
                        Color = list[rnd.Next(0, 4)],
                    };
                }
            }
        }
    }
}
