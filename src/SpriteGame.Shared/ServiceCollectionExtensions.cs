using Microsoft.Extensions.DependencyInjection;
using SpriteGame.Shared.Services;

namespace SpriteGame.Shared;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services)
    {
        services.AddSingleton<FileStorageService>();
        
        return services;
    }
}