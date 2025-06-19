using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArcadeScore.Domain.Interfaces;
using ArcadeScore.Domain.Models;

namespace ArcadeScore.Infrastructure.Repositories
{
    /// <summary>
    /// Provides an in-memory implementation of the <see cref="IScoreRepository"/> interface,
    /// used to manage <see cref="Score"/> entities without the need for a database.
    /// </summary>
    public class InMemoryScoreRepository : InMemoryRepository<Score>, IScoreRepository
    {
        /// <summary>
        /// Retrieves all scores registered by a specific player, ordered by the date the games were played.
        /// </summary>
        /// <param name="playerId">The unique identifier of the player.</param>
        /// <returns>A task containing an enumerable collection of the player's scores, ordered chronologically.</returns>
        public Task<IEnumerable<Score>> GetByPlayerIdAsync(int playerId)
        {
            var scores = _entities
                .Where(s => s.PlayerId == playerId)
                .OrderBy(s => s.DatePlayed)
                .AsEnumerable(); 

            return Task.FromResult(scores);
        }
    }
}
