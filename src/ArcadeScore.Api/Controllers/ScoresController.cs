using System.Collections.Generic;
using System.Threading.Tasks;
using ArcadeScore.Application.Commands.Score;
using ArcadeScore.Application.DTOs;
using ArcadeScore.Application.Queries.Score;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArcadeScore.Api.Controllers
{
    /// <summary>
    /// API Controller responsible for managing scores.
    /// Provides endpoints to register new scores and retrieve the top 10 ranking.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ScoresController : ControllerBase
    {
        /// <summary>
        /// Handles the dispatching of commands and queries to their respective handlers using the Mediator pattern.
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoresController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator used to handle requests.</param>
        public ScoresController(IMediator mediator)
            => _mediator = mediator;

        /// <summary>
        /// Registers a new score using the provided command.
        /// </summary>
        /// <param name="command">The command containing player name, score, and date played.</param>
        /// <returns>An HTTP 204 No Content response upon successful registration.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterScore([FromBody] RegisterScoreCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Retrieves the top 10 scores ranking.
        /// </summary>
        /// <returns>An HTTP 200 OK response containing a list of the top 10 scores.</returns>
        [HttpGet("ranking")]
        [ProducesResponseType(typeof(IEnumerable<ScoreResultDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTop10Ranking()
        {
            var result = await _mediator.Send(new GetTop10ScoresQuery());
            return Ok(result);
        }
    }
}
