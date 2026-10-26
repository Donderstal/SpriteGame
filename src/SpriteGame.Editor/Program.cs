using Editor.UseCases;
using Editor.UseCases.Interfaces;
using SpriteGame.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
builder.ConfigureDatabase();
builder.AddRedisClientBuilder("cache")
    .WithOutputCache();

// Add custom dependencies
builder.Services.AddRepositories();

builder.Services.AddScoped<IInsertImageUseCase, InsertImageUseCase>();

// Add ASP.Net helper dependencies
builder.Services.AddValidation();
builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseOutputCache();
app.MapDefaultEndpoints();

await app.MigrateDbAsync();

var baseGroup = app.MapGroup("/api/");

app.Run();