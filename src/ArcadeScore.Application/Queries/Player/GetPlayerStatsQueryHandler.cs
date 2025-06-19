using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArcadeScore.Application.DTOs;
using ArcadeScore.Domain.Interfaces;
using MediatR;

namespace ArcadeScore.Application.Queries.Player
{
    /// <summary>
    /// Handles the query to retrieve detailed statistics for a specific player,
    /// including total games played, average score, highest and lowest scores,
    /// number of record-breaking games, and the time span of gameplay.
    /// </summary>
    public class GetPlayerStatsQueryHandler : IRequestHandler<GetPlayerStatsQuery, PlayerStatsResultDTO>
    {
        /// <summary>
        /// Repository used to access and manage player data.
        /// </summary>
        private readonly IPlayerRepository _playerRepository;
        /// <summary>
        /// Repository used to access and manage score data.
        /// </summary>
        private readonly IScoreRepository _scoreRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPlayerStatsQueryHandler"/> class.
        /// </summary>
        /// <param name="playerRepository">The repository to access player data.</param>
        /// <param name="scoreRepository">The repository to access score data.</param>
        public GetPlayerStatsQueryHandler(IPlayerRepository playerRepository, IScoreRepository scoreRepository)
        {
            _playerRepository = playerRepository;
            _scoreRepository = scoreRepository;
        }

        /// <summary>
        /// Handles the request to retrieve statistics for a specific player.
        /// </summary>
        /// <param name="request">The query containing the player ID.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the player's statistics.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the player with the specified ID is not found.</exception>
        public async Task<PlayerStatsResultDTO> Handle(GetPlayerStatsQuery request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetByIdAsync(request.PlayerId);

            if (player == null)
                throw new KeyNotFoundException("Jogador não encontrado.");

            var scores = (await _scoreRepository.GetByPlayerIdAsync(player.Id)).ToList();

            if (!scores.Any())
            {
                return new PlayerStatsResultDTO
                {
                    PlayerId = player.Id,
                    PlayerName = player.Name,
                    TotalGames = 0,
                    AverageScore = 0,
                    HighestScore = 0,
                    LowestScore = 0,
                    TimesBrokeRecord = 0,
                    PlayPeriod = TimeSpan.Zero
                };
            }

            int highest = scores.First().Value;
            int recordBeaten = 0;

            foreach (var score in scores.Skip(1))
            {
                if (score.Value > highest)
                {
                    highest = score.Value;
                    recordBeaten++;
                }
            }

            return new PlayerStatsResultDTO
            {
                PlayerId = player.Id,
                PlayerName = player.Name,
                TotalGames = scores.Count,
                AverageScore = scores.Average(s => s.Value),
                HighestScore = scores.Max(s => s.Value),
                LowestScore = scores.Min(s => s.Value),
                TimesBrokeRecord = recordBeaten,
                PlayPeriod = scores.Max(s => s.DatePlayed) - scores.Min(s => s.DatePlayed)
            };
        }
    }
}
