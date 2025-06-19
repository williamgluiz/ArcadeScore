using ArcadeScore.Domain.Interfaces;
using ArcadeScore.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ArcadeScore.Api.Configurations
{
    /// <summary>
    /// Provides extension methods to configure dependency injection for application services, repositories, and other components.
    /// </summary>
    public static class DependecyInjectionConfig
    {
        /// <summary>
        /// Registers the main application dependencies in the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection to add the dependencies to.</param>
        /// <returns>The service collection with the registered dependencies.</returns>
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IPlayerRepository, InMemoryPlayerRepository>();
            services.AddSingleton<IScoreRepository, InMemoryScoreRepository>();
            return services;
        }
    }
}
