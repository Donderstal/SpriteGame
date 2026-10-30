using SpriteGame.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var postgres = builder.AddPostgres("postgres")
    .WithDataVolume(isReadOnly: false)
    .WithPgWeb(pgWeb => pgWeb.WithHostPort(5050));

var database = postgres.AddDatabase("spritegame");

builder.AddDockerfile("game-api", "..", "SpriteGame.Game/Dockerfile")
    .WithHttpEndpoint(port: 5101, targetPort: 8080)
    .AddApiResources(database, cache);

builder.AddDockerfile("editor-api", "..", "SpriteGame.Editor/Dockerfile")
    .WithHttpEndpoint(port: 5102, targetPort: 8080)
    .AddApiResources(database, cache);

builder.Build().Run();
