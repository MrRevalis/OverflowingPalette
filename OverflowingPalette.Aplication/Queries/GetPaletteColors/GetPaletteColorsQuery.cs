using MediatR;

namespace OverflowingPalette.Aplication.Queries.GetPaletteColors
{
    public class GetPaletteColorsQuery : IRequest<IEnumerable<string>>
    {
    }
}
