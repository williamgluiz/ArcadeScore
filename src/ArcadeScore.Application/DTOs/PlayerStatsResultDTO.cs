using System;

namespace ArcadeScore.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object representing aggregated statistics for a player,
    /// including total games played, average score, highest and lowest scores,
    /// number of times the player broke their own record, and the time span of gameplay.
    /// </summary>
    public class PlayerStatsResultDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the player.
        /// </summary>
        public int PlayerId { get; set; }
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string PlayerName { get; set; }
        /// <summary>
        /// Gets or sets the total number of games played by the player.
        /// </summary>
        public int TotalGames { get; set; }
        /// <summary>
        /// Gets or sets the average score achieved by the player.
        /// </summary>
        public double AverageScore { get; set; }
        /// <summary>
        /// Gets or sets the highest score achieved by the player.
        /// </summary>
        public int HighestScore { get; set; }
        /// <summary>
        /// Gets or sets the lowest score achieved by the player.
        /// </summary>
        public int LowestScore { get; set; }
        /// <summary>
        /// Gets or sets the number of times the player broke their own record.
        /// </summary>
        public int TimesBrokeRecord { get; set; }
        /// <summary>
        /// Gets or sets the time period between the player's first and last game played.
        /// </summary>
        public TimeSpan PlayPeriod { get; set; }
    }
}
