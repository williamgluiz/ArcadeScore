using System;
using System.Linq;
using System.Threading.Tasks;
using ArcadeScore.Domain.Interfaces;
using ArcadeScore.Domain.Models;

namespace ArcadeScore.Infrastructure.Repositories
{
    /// <summary>
    /// Provides an in-memory implementation of the <see cref="IPlayerRepository"/> interface,
    /// used to manage <see cref="Player"/> entities without relying on a database.
    /// </summary>
    public class InMemoryPlayerRepository : InMemoryRepository<Player>, IPlayerRepository
    {
        /// <summary>
        /// Retrieves a player entity by their name, performing a case-insensitive comparison.
        /// </summary>
        /// <param name="name">The name of the player to search for.</param>
        /// <returns>A task containing the player entity if found; otherwise, null.</returns>
        public Task<Player> GetByNameAsync(string name)
        {
            var player = _entities.FirstOrDefault(p =>
                p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(player);
        }
    }
}
