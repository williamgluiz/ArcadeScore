using System;

namespace ArcadeScore.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object representing the result of a score query,
    /// including player name, score value, and the date the score was recorded.
    /// </summary>
    public class ScoreResultDTO
    {
        /// <summary>
        /// Gets or sets the name of the player who achieved the score.
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
