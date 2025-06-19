using System.Collections.Generic;
using System.Threading.Tasks;
using ArcadeScore.Domain.Models;

namespace ArcadeScore.Domain.Interfaces
{
    /// <summary>
    /// Defines the contract for a repository managing <see cref="Score"/> entities.
    /// Extends the generic <see cref="IRepository{TEntity}"/> interface.
    /// </summary>
    public interface IScoreRepository : IRepository<Score>
    {
        /// <summary>
        /// Retrieves all scores associated with the specified player, ordered by the date the game was played.
        /// </summary>
        /// <param name="playerId">The unique identifier of the player.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of scores for the specified player.</returns>
        Task<IEnumerable<Score>> GetByPlayerIdAsync(int playerId);
    }
}
