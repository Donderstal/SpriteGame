using SpriteGame.Domain.Constants;

namespace SpriteGame.AppHost;

public static class IResourceBuilderExtensions
{
    public static void AddApiResources(this IResourceBuilder<ProjectResource> builder, 
        IResourceBuilder<PostgresDatabaseResource> database,
        IResourceBuilder<RedisResource> cache)
    {
        builder.WithReference(database)
            .WithReference(cache)
            .WaitFor(database)
            .WithHttpHealthCheck("/health")
            .WithExternalHttpEndpoints()
            .WithVolume(
                FileStorageConstants.VolumeName, 
                FileStorageConstants.StorageRootPath, 
                env: FileStorageConstants.StorageRootPathEnvVar
            );
    }
}