using Microsoft.Extensions.Hosting;

namespace SpriteGame.Persistence;

public static class HostApplicationBuilderExtensions
{
    public static IHostApplicationBuilder ConfigureDatabase(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDataSource(connectionName: "spritegame");
        builder.AddNpgsqlDbContext<SpriteGameDbContext>(connectionName: "spritegame");
        return builder;
    }
}