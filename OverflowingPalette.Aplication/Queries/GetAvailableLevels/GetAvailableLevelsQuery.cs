using MediatR;
using OverflowingPalette.Shared.Models;

namespace OverflowingPalette.Application.Queries.GetAvailableLevels
{
    public class GetAvailableLevelsQuery : IRequest<IEnumerable<AvailableLevels>>
    {
    }
}
