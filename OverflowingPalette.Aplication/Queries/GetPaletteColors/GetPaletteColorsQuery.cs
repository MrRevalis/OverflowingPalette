using MediatR;

namespace OverflowingPalette.Application.Queries.GetPaletteColors
{
    public record GetPaletteColorsQuery : IRequest<IEnumerable<string>>
    {
    }
}
