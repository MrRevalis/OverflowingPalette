using MediatR;

using Microsoft.AspNetCore.Mvc;
using OverflowingPalette.Application.Queries.GetPaletteColors;

namespace OverflowingPalette.API.Controlers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("colors")]
        [HttpGet]
        public async Task<IActionResult> GetPaletteColors()
        {
            var query = new GetPaletteColorsQuery();

            var result = await _mediator.Send(query);

            return this.Ok(result);
        }
    }
}
