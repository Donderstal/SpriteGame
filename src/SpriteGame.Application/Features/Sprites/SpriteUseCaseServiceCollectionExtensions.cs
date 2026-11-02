using Microsoft.Extensions.DependencyInjection;
using SpriteGame.Application.Features.Sprites.GetSprite;

namespace SpriteGame.Application.Features.Sprites;

internal static class SpriteUseCaseServiceCollectionExtensions
{
    public static IServiceCollection AddSpriteUseCases(this IServiceCollection services)
    {
        services.AddScoped<GetSpriteUseCase>();
        
        return services;
    }
}