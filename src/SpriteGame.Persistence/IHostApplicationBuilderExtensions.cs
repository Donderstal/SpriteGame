using Microsoft.Extensions.Hosting;

namespace SpriteGame.Persistence;

// ReSharper disable once InconsistentNaming
public static class IHostApplicationBuilderExtensions
{
    public static IHostApplicationBuilder ConfigureDatabase(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDataSource(connectionName: "spritegame");
        builder.AddNpgsqlDbContext<SpriteGameDbContext>(connectionName: "spritegame");
        return builder;
    }
}