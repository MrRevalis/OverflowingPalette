using MediatR;

namespace OverflowingPalette.Application.Queries.GetPaletteColors
{
    public class GetPaletteColorsQuery : IRequest<IEnumerable<string>>
    {
    }
}
