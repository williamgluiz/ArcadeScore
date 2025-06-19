using System.Threading.Tasks;
using ArcadeScore.Domain.Models;

namespace ArcadeScore.Domain.Interfaces
{
    /// <summary>
    /// Defines the contract for a repository managing <see cref="Player"/> entities.
    /// Extends the generic <see cref="IRepository{TEntity}"/> interface.
    /// </summary>
    public interface IPlayerRepository : IRepository<Player>
    {
        /// <summary>
        /// Retrieves a player entity by their name, performing a case-insensitive search.
        /// </summary>
        /// <param name="name">The name of the player to find.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the player entity if found; otherwise, null.</returns>
        Task<Player> GetByNameAsync(string name);
    }
}
