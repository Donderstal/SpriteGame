using Microsoft.Extensions.DependencyInjection;
using SpriteGame.Domain.Entities.Animations;
using SpriteGame.Domain.Entities.Assets;
using SpriteGame.Domain.Entities.Events;
using SpriteGame.Domain.Entities.Interactability;
using SpriteGame.Domain.Entities.Maps;
using SpriteGame.Domain.Entities.PlayerData;
using SpriteGame.Domain.Entities.Sprites;
using SpriteGame.Persistence.Repositories;

namespace SpriteGame.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEntityRepository<Animation>, EntityRepository<Animation>>()
            .AddScoped<IEntityRepository<AnimationFrame>, EntityRepository<AnimationFrame>>()
            .AddScoped<IEntityRepository<Asset>, EntityRepository<Asset>>()
            .AddScoped<IEntityRepository<Condition>, EntityRepository<Condition>>()
            .AddScoped<IEntityRepository<Event>, EntityRepository<Event>>()
            .AddScoped<IEntityRepository<EventScene>, EntityRepository<EventScene>>()
            .AddScoped<IEntityRepository<EventSceneAnimation>, EntityRepository<EventSceneAnimation>>()
            .AddScoped<IEntityRepository<EventTrigger>, EntityRepository<EventTrigger>>()
            .AddScoped<IEntityRepository<Door>, EntityRepository<Door>>()
            .AddScoped<IEntityRepository<Inventory>, EntityRepository<Inventory>>()
            .AddScoped<IEntityRepository<InventoryItem>, EntityRepository<InventoryItem>>()
            .AddScoped<IEntityRepository<Interaction>, EntityRepository<Interaction>>()
            .AddScoped<IEntityRepository<InteractiveMapLayer>, EntityRepository<InteractiveMapLayer>>()
            .AddScoped<IEntityRepository<Item>, EntityRepository<Item>>()
            .AddScoped<IEntityRepository<Map>, EntityRepository<Map>>()
            .AddScoped<IEntityRepository<MapLayerSprite>, EntityRepository<MapLayerSprite>>()
            .AddScoped<IEntityRepository<Neighbourhood>, EntityRepository<Neighbourhood>>()
            .AddScoped<IEntityRepository<Player>, EntityRepository<Player>>()
            .AddScoped<IEntityRepository<PlayerInteractions>, EntityRepository<PlayerInteractions>>()
            .AddScoped<IEntityRepository<SpriteAnimation>, EntityRepository<SpriteAnimation>>()
            .AddScoped<IEntityRepository<Sprite>, EntityRepository<Sprite>>()
            .AddScoped<IEntityRepository<StaticMapLayer>, EntityRepository<StaticMapLayer>>()
            .AddScoped<IEntityRepository<TileSheet>, EntityRepository<TileSheet>>()
            .AddScoped<IEntityRepository<Trigger>, EntityRepository<Trigger>>()
            .AddScoped<IEntityRepository<TriggerableEvent>, EntityRepository<TriggerableEvent>>();
        
        return services;
    }
}