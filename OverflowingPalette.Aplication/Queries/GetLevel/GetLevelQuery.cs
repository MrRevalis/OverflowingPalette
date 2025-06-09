using MediatR;
using OverflowingPalette.Shared.Models;

namespace OverflowingPalette.Application.Queries.GetLevel
{
    public record GetLevelQuery : IRequest<LevelDetailsDto>
    {
        public int LevelNumber { get; set; }
    }
}
