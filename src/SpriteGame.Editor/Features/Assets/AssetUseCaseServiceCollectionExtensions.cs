using Editor.Features.Assets.DeleteAsset;
using Editor.Features.Assets.GetAsset;
using Editor.Features.Assets.GetAssetsByType;
using Editor.Features.Assets.PostAsset;

namespace Editor.Features.Assets;

public static class AssetUseCaseServiceCollectionExtensions
{
    public static IServiceCollection AddAssetUseCases(this IServiceCollection services)
    {
        services.AddScoped<DeleteAssetUseCase>()
            .AddScoped<GetAssetUseCase>()
            .AddScoped<GetAssetsByTypeUseCase>()
            .AddScoped<PostAssetUseCase>();
        
        return services;
    }
}