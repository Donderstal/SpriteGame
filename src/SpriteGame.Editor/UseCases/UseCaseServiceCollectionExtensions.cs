using Editor.UseCases.Images;

namespace Editor.UseCases;

public static class UseCaseServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<PostAssetUseCase>();
        return services;
    }
}