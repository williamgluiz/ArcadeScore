using ArcadeScore.Application.DTOs;
using MediatR;

namespace ArcadeScore.Application.Queries.Player
{
    /// <summary>
    /// Query request to retrieve detailed statistics for a specific player.
    /// </summary>
    public class GetPlayerStatsQuery : IRequest<PlayerStatsResultDTO>
    {
        /// <summary>
        /// Gets the unique identifier of the player.
        /// </summary>
        public int PlayerId { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPlayerStatsQuery"/> class with the specified player ID.
        /// </summary>
        /// <param name="playerId">The unique identifier of the player whose statistics are to be retrieved.</param>
        public GetPlayerStatsQuery(int playerId)
        {
            PlayerId = playerId;
        }
    }
}
