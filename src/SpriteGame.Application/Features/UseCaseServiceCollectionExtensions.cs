using Microsoft.Extensions.DependencyInjection;
using SpriteGame.Application.Features.Sprites;

namespace SpriteGame.Application.Features;

internal static class UseCaseServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddSpriteUseCases();
        
        return services;
    }
}