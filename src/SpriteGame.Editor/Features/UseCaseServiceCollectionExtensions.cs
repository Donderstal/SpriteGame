using Editor.Features.Assets;

namespace Editor.Features;

public static class UseCaseServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddAssetUseCases();
        
        return services;
    }
}