using MediatR;

namespace OverflowingPalette.Aplication.Queries.GetPaletteColors
{
    public class GetPaletteColorsQueryHandler : IRequestHandler<GetPaletteColorsQuery, IEnumerable<string>>
    {
        public Task<IEnumerable<string>> Handle(GetPaletteColorsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult<IEnumerable<string>>
                ([
                    "#62b4cf",
                    "#D22B2B",
                    "#FFC300",
                    "#AFE1AF"
                ]);
        }
    }
}
