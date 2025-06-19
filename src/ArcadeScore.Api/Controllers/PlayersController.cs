using System.Threading.Tasks;
using ArcadeScore.Application.DTOs;
using ArcadeScore.Application.Queries.Player;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArcadeScore.Api.Controllers
{
    /// <summary>
    /// API Controller responsible for managing players.
    /// Provides endpoints to retrieve player-related information and statistics.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        /// <summary>
        /// Handles the dispatching of commands and queries to their respective handlers using the Mediator pattern.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayersController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator used to handle requests.</param>
        public PlayersController(IMediator mediator)
            => _mediator = mediator;

        /// <summary>
        /// Retrieves detailed statistics for a specific player by their identifier.
        /// </summary>
        /// <param name="playerId">The unique identifier of the player.</param>
        /// <returns>An HTTP 200 OK response containing the player's statistics.</returns>
        [HttpGet("{playerId}/stats")]
        [ProducesResponseType(typeof(PlayerStatsResultDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStats(int playerId)
        {
            var result = await _mediator.Send(new GetPlayerStatsQuery(playerId));
            return Ok(result);
        }
    }
}
