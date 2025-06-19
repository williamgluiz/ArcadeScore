using System;

namespace ArcadeScore.Domain.Models
{
    /// <summary>
    /// Base abstract class for all entities, providing a unique identifier,
    /// creation timestamp, and last updated timestamp functionality.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        public int Id { get; protected set; }
        /// <summary>
        /// Gets the date and time when the entity was created (UTC).
        /// </summary>
        public DateTime CreatedAt { get; protected set; }
        /// <summary>
        /// Gets the date and time when the entity was last updated (UTC). Null if never updated.
        /// </summary>
        public DateTime? LastUpdatedAt { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class,
        /// setting the creation timestamp to the current UTC time.
        /// </summary>
        protected Entity() => CreatedAt = DateTime.UtcNow;

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class with the specified identifier,
        /// setting the creation timestamp to the current UTC time.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        protected Entity(int id)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Updates the last updated timestamp to the current UTC time.
        /// </summary>
        public void SetUpdated()
        {
            LastUpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current entity
        /// based on the entity's identifier.
        /// </summary>
        /// <param name="obj">The object to compare with the current entity.</param>
        /// <returns>True if the objects are of the same type and have the same identifier; otherwise, false.</returns>
        public override bool Equals(object obj)
            => obj is Entity other && Id == other.Id;

        /// <summary>
        /// Returns a hash code for this entity based on its identifier.
        /// </summary>
        /// <returns>A hash code for the current entity.</returns>
        public override int GetHashCode()
            => Id.GetHashCode();
    }
}
