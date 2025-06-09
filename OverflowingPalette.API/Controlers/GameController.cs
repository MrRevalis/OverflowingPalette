using MediatR;

using Microsoft.AspNetCore.Mvc;
using OverflowingPalette.Application.Queries.GetLevel;
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

        [Route("{levelNumber:int}")]
        [HttpGet]
        public async Task<IActionResult> GetLevelForGame([FromRoute] int levelNumber)
        {
            var query = new GetLevelQuery
            {
                LevelNumber = levelNumber
            };

            var result = await _mediator.Send(query);

            return this.Ok(result);
        }

        [Route("levels")]
        [HttpGet]
        public async Task<IActionResult> GetListOfLevels()
        {
            var query = new GetLevelsQuery();

            var result = await _mediator.Send(query);

            return this.Ok(result);
        }
    }
}
