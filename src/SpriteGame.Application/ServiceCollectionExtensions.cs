using Microsoft.Extensions.DependencyInjection;
using SpriteGame.Application.Features;
using SpriteGame.Application.Services;

namespace SpriteGame.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services)
    {
        services.AddSingleton<FileStorageService>();
        services.AddUseCases();
        
        return services;
    }
}