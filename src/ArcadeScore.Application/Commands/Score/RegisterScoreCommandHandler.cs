using System.Threading;
using System.Threading.Tasks;
using ArcadeScore.Domain.Interfaces;
using ArcadeScore.Domain.Models;
using MediatR;

namespace ArcadeScore.Application.Commands.Score
{
    /// <summary>
    /// Handles the command to register a new score for a player.
    /// Processes the command by validating and storing the score in the repository.
    /// </summary>
    public class RegisterScoreCommandHandler : IRequestHandler<RegisterScoreCommand, Unit>
    {
        /// <summary>
        /// Repository for accessing and managing player entities.
        /// </summary>
        private readonly IPlayerRepository _playerRepository;
        /// <summary>
        /// Repository for accessing and managing score entities.
        /// </summary>
        private readonly IScoreRepository _scoreRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterScoreCommandHandler"/> class,
        /// with the specified player and score repositories.
        /// </summary>
        /// <param name="playerRepository">Repository for managing player data.</param>
        /// <param name="scoreRepository">Repository for managing score data.</param>
        public RegisterScoreCommandHandler(IPlayerRepository playerRepository, IScoreRepository scoreRepository)
        {
            _playerRepository = playerRepository;
            _scoreRepository = scoreRepository;
        }

        /// <summary>
        /// Handles the registration of a new score for a player.
        /// Checks if the player exists; if not, creates a new player.
        /// Then creates and stores the new score.
        /// </summary>
        /// <param name="request">The command containing the player's name, score value, and date played.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A <see cref="Unit"/> value signaling the completion of the command.</returns>
        public async Task<Unit> Handle(RegisterScoreCommand request, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.GetByNameAsync(request.PlayerName);

            if (player == null)
            {
                player = new Player(request.PlayerName);
                await _playerRepository.AddAsync(player);
            }

            var score = new Domain.Models.Score(player.Id, request.Score, request.DatePlayed);
            await _scoreRepository.AddAsync(score);

            return Unit.Value;
        }
    }
}
