using ArcadeScore.Application.Behaviors;
using ArcadeScore.Application.Commands.Score;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ArcadeScore.Api.Configurations
{
    /// <summary>
    /// Provides extension methods to configure MediatR for handling application commands and queries.
    /// </summary>
    public static class MediatorConfig
    {
        /// <summary>
        /// Configures MediatR and registers FluentValidation validators for the application.
        /// </summary>
        /// <param name="services">The IServiceCollection instance used for dependency injection.</param>
        /// <returns>The updated IServiceCollection with MediatR and validation services registered.</returns>
        public static IServiceCollection AddMediatorConfig(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterScoreCommandHandler).Assembly));

            //services.AddValidatorsFromAssemblyContaining<CreateCandidateValidator>();

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            return services;
        }
    }
}
