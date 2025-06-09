using MediatR;
using Microsoft.EntityFrameworkCore;
using OverflowingPalette.Domain.Models;
using OverflowingPalette.Domain.Repositories.Base;
using OverflowingPalette.Shared.Models;

namespace OverflowingPalette.Application.Queries.GetAvailableLevels
{
    internal class GetAvailableLevelsQueryHandler : IRequestHandler<GetAvailableLevelsQuery, IEnumerable<AvailableLevels>>
    {
        private readonly IGenericRepository<Level> _levelRepository;

        public GetAvailableLevelsQueryHandler(IGenericRepository<Level> levelRepository)
        {
            _levelRepository = levelRepository;
        }

        public async Task<IEnumerable<AvailableLevels>> Handle(GetAvailableLevelsQuery request, CancellationToken cancellationToken)
        {
            var availableLevels = await _levelRepository
                .Get()
                .Select(level => new AvailableLevels(level.LevelNumber, level.Name))
                .ToListAsync();

            return availableLevels;
        }
    }
}
