using MediatR;
using OverflowingPalette.Domain.Models;
using OverflowingPalette.Domain.Repositories.Base;

namespace OverflowingPalette.Application.Queries.GetPaletteColors
{
    public class GetPaletteColorsQueryHandler : IRequestHandler<GetPaletteColorsQuery, IEnumerable<string>>
    {
        private readonly IGenericRepository<LevelPaletteColor> _levelPaletteRepository;

        public GetPaletteColorsQueryHandler(IGenericRepository<LevelPaletteColor> levelPaletteRepository)
        {
            _levelPaletteRepository = levelPaletteRepository;
        }

        public async Task<IEnumerable<string>> Handle(GetPaletteColorsQuery request, CancellationToken cancellationToken)
        {
            var results = await _levelPaletteRepository.GetAllAsync();

            return results.Select(x => x.Color);
        }
    }
}
