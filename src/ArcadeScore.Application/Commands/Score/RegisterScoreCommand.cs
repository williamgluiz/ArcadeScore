using System;
using MediatR;

namespace ArcadeScore.Application.Commands.Score
{
    /// <summary>
    /// Command to register a new score for a player.
    /// Contains the player's name, the score value, and the date the score was achieved.
    /// </summary>
    public class RegisterScoreCommand : IRequest<Unit>
    {
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string PlayerName { get; set; }
        /// <summary>
        /// Gets or sets the score value achieved by the player.
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the score was recorded.
        /// </summary>
        public DateTime DatePlayed { get; set; }
    }
}
