using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArcadeScore.Application.DTOs;
using ArcadeScore.Domain.Interfaces;
using MediatR;

namespace ArcadeScore.Application.Queries.Score
{
    /// <summary>
    /// Handles the query to retrieve the top 10 highest scores from the system,
    /// including player names, score values, and dates played.
    /// </summary>
    public class GetTop10ScoresQueryHandler : IRequestHandler<GetTop10ScoresQuery, IEnumerable<ScoreResultDTO>>
    {
        /// <summary>
        /// Repository used to access and manage player data.
        /// </summary>
        private readonly IScoreRepository _scoreRepository;
        /// <summary>
        /// Repository used to access and manage score data.
        /// </summary
        private readonly IPlayerRepository _playerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTop10ScoresQueryHandler"/> class.
        /// </summary>
        /// <param name="scoreRepository">The repository for accessing score data.</param>
        /// <param name="playerRepository">The repository for accessing player data.</param>
        public GetTop10ScoresQueryHandler(IScoreRepository scoreRepository, IPlayerRepository playerRepository)
        {
            _scoreRepository = scoreRepository;
            _playerRepository = playerRepository;
        }

        /// <summary>
        /// Handles the request to retrieve the top 10 highest scores across all players.
        /// </summary>
        /// <param name="request">The query request (no parameters required).</param>
        /// <param name="cancellationToken">A cancellation token for the operation.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a collection of the top 10 scores,
        /// each including the player name, score value, and date played.
        /// </returns>
        public async Task<IEnumerable<ScoreResultDTO>> Handle(GetTop10ScoresQuery request, CancellationToken cancellationToken)
        {
            var allPlayers = await _playerRepository.GetAllAsync();
            var allScores = await _scoreRepository.GetAllAsync();

            var topScores = allScores
                .OrderByDescending(s => s.Value)
                .Take(10)
                .Select(s =>
                {
                    var player = allPlayers.FirstOrDefault(p => p.Id == s.PlayerId);
                    return new ScoreResultDTO
                    {
                        PlayerName = player?.Name ?? "Unknown",
                        Score = s.Value,
                        DatePlayed = s.DatePlayed
                    };
                });

            return topScores;
        }
    }
}
