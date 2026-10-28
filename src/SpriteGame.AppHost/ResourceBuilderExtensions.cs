using SpriteGame.Domain.Constants;

namespace SpriteGame.AppHost;

public static class ResourceBuilderExtensions
{
    public static void AddApiResources(this IResourceBuilder<ContainerResource> builder,
        IResourceBuilder<PostgresDatabaseResource> database,
        IResourceBuilder<RedisResource> cache)
    {
        builder.WithReference(database)
            .WithReference(cache)
            .WaitFor(database)
            .WithHttpEndpoint(targetPort: 8080)
            .WithExternalHttpEndpoints()
            .WithVolume(
                FileStorageConstants.VolumeName,
                FileStorageConstants.StorageRootPath,
                env: FileStorageConstants.StorageRootPathEnvVar
            );
    }
}