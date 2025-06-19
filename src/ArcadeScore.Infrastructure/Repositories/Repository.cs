using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArcadeScore.Domain.Interfaces;
using ArcadeScore.Domain.Models;

namespace ArcadeScore.Infrastructure.Repositories
{
    /// <summary>
    /// Represents a generic in-memory repository for storing and managing entities of type <typeparamref name="TEntity"/>.
    /// Designed for use in development and testing scenarios without a backing database.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to be stored, which must inherit from <see cref="Entity"/>.</typeparam>
    public abstract class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// The in-memory list used to store entities of type <typeparamref name="TEntity"/>.
        /// </summary>
        protected readonly List<TEntity> _entities = new();
        /// <summary>
        /// The next available unique identifier to be assigned to a new entity.
        /// </summary>
        private int _nextId = 1;
        /// <summary>
        /// Indicates whether the repository has been disposed.
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// Retrieves all entities from the in-memory store.
        /// </summary>
        public virtual Task<IEnumerable<TEntity>> GetAllAsync()
            => Task.FromResult(_entities.AsEnumerable());

        /// <summary>
        /// Retrieves a single entity by its Id.
        /// </summary>
        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(entity);
        }

        /// <summary>
        /// Adds a new entity to the in-memory store, assigning a unique Id.
        /// </summary>
        public virtual Task AddAsync(TEntity entity)
        {
            // Define um Id incremental caso ainda não tenha
            if (entity.Id == 0)
            {
                typeof(TEntity)
                    .GetProperty("Id", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public)
                    ?.SetValue(entity, _nextId++);
            }

            _entities.Add(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Updates an existing entity by replacing the one with the same Id.
        /// </summary>
        public virtual Task UpdateAsync(TEntity entity)
        {
            var index = _entities.FindIndex(e => e.Id == entity.Id);
            if (index == -1)
                throw new InvalidOperationException("Entity not found");

            _entities[index] = entity;
            return Task.CompletedTask;
        }

        /// <summary>
        /// Deletes an entity by Id.
        /// </summary>
        public virtual Task DeleteAsync(int id)
        {
            var entity = _entities.FirstOrDefault(e => e.Id == id);
            if (entity == null)
                throw new InvalidOperationException("Entity not found");

            _entities.Remove(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Disposes the repository, clearing the in-memory store.
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _entities.Clear();
                _disposed = true;
            }
        }
    }

}
