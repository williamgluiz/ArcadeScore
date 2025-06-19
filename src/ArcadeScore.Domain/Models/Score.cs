using System;

namespace ArcadeScore.Domain.Models
{
    /// <summary>
    /// Represents a score achieved by a player in a game session, including the player ID,
    /// score value, and the date the game was played.
    /// </summary>
    public class Score : Entity
    {
        /// <summary>
        /// Gets the unique identifier of the player associated with this score.
        /// </summary>
        public int PlayerId { get; private set; }
        /// <summary>
        /// Gets the value of the score achieved by the player.
        /// </summary>
        public int Value { get;  private set; }
        /// <summary>
        /// Gets the date and time when the score was recorded.
        /// </summary>
        public DateTime DatePlayed { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Score"/> class with default values.
        /// </summary>
        public Score() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Score"/> class with specified player, score value, and date.
        /// </summary>
        /// <param name="playerId">The unique identifier of the player who achieved the score.</param>
        /// <param name="value">The score value achieved by the player.</param>
        /// <param name="datePlayed">The date when the score was recorded.</param>
        public Score(int playerId, int value, DateTime datePlayed)
        {
            PlayerId = playerId;
            Value = value;
            DatePlayed = datePlayed;
        }

        /// <summary>
        /// Updates the score value and sets the last updated timestamp.
        /// </summary>
        /// <param name="newValue">The new score value to be assigned.</param>
        public void UpdateValue(int newValue)
        {
            Value = newValue;
            SetUpdated();
        }

        /// <summary>
        /// Updates the date the score was recorded and sets the last updated timestamp.
        /// </summary>
        /// <param name="newDate">The new date to be assigned to the score.</param>
        public void UpdateDate(DateTime newDate)
        {
            DatePlayed = newDate;
            SetUpdated();
        }
    }
}
