using Editor.Features.Assets.PostAsset;

namespace Editor.Features;

public static class UseCaseServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<PostAssetUseCase>();
        return services;
    }
}