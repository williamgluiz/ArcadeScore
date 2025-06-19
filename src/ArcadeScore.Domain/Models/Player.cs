namespace ArcadeScore.Domain.Models
{
    /// <summary>
    /// Represents a player who participates in arcade games and accumulates scores.
    /// </summary>
    public class Player : Entity
    {
        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with default values.
        /// </summary>
        public Player() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with the specified player name.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        public Player(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Renames the player and updates the last updated timestamp.
        /// </summary>
        /// <param name="newName">The new name to assign to the player.</param>
        public void Rename(string newName)
        {
            Name = newName;
            SetUpdated();
        }
    }
}
