var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var postgres = builder.AddPostgres("postgres")
    .WithDataVolume(isReadOnly: false)
    .WithPgWeb(pgWeb => pgWeb.WithHostPort(5050));

var database = postgres.AddDatabase("spritegame");

builder.AddProject<Projects.SpriteGame_Game>("game-api")
    .WithReference(database)
    .WithReference(cache)
    .WaitFor(database)
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();

builder.AddProject<Projects.SpriteGame_Editor>("editor-api")
    .WithReference(database)
    .WithReference(cache)
    .WaitFor(database)
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();

builder.Build().Run();
