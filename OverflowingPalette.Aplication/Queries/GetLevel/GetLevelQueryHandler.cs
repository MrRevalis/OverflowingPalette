using MediatR;
using Microsoft.EntityFrameworkCore;
using OverflowingPalette.Domain.Models;
using OverflowingPalette.Domain.Repositories.Base;
using OverflowingPalette.Shared.Models;

namespace OverflowingPalette.Application.Queries.GetLevel
{
    public class GetLevelQueryHandler : IRequestHandler<GetLevelQuery, LevelDetailsDto>
    {
        private readonly IGenericRepository<Level> _levelRepository;

        public GetLevelQueryHandler(IGenericRepository<Level> levelRepository)
        {
            _levelRepository = levelRepository;
        }

        public async Task<LevelDetailsDto> Handle(GetLevelQuery request, CancellationToken cancellationToken)
        {
            var level = await _levelRepository
                .Get()
                .Include(l => l.InitialBlockStates)
                .Include(l => l.Palette)
                .Where(l => l.LevelNumber == request.LevelNumber)
                    .Select(l => new LevelDetailsDto
                    {
                        LevelNumber = l.LevelNumber,
                        MaxMoves = l.MaxMoves,
                        Width = l.Width,
                        Height = l.Height,
                        TargetColor = l.TargetColor,
                        Palette = l.Palette.Select(p => new PaletteColorDto(p.Color)).ToList(),
                        InitialState = l.InitialBlockStates.Select(b => new BlockStateDto
                        {
                            PositionX = b.PositionX,
                            PositionY = b.PositionY,
                            Color = b.Color
                        }).ToList()
                    })
                    .FirstOrDefaultAsync();

            return level;
        }
    }
}
