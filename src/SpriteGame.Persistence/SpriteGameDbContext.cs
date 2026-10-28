using Microsoft.EntityFrameworkCore;
using SpriteGame.Domain.Entities.Animations;
using SpriteGame.Domain.Entities.Assets;
using SpriteGame.Domain.Entities.Events;
using SpriteGame.Domain.Entities.Interactability;
using SpriteGame.Domain.Entities.Maps;
using SpriteGame.Domain.Entities.PlayerData;
using SpriteGame.Domain.Entities.Sprites;

namespace SpriteGame.Persistence;

public class SpriteGameDbContext(DbContextOptions<SpriteGameDbContext> options) : DbContext(options)
{
    public DbSet<Animation> Animations { get; set; }
    public DbSet<AnimationFrame> AnimationFrames { get; set; }
    public DbSet<Asset> Assets { get; set; }
    
    public DbSet<Condition> Conditions { get; set; }
    
    public DbSet<Event> Events { get; set; }
    public DbSet<EventScene> EventScenes { get; set; }
    public DbSet<EventSceneAnimation> EventSceneAnimations { get; set; }
    public DbSet<EventTrigger> EventTriggers { get; set; }
    
    public DbSet<Door> Doors { get; set; }
    
    public DbSet<Inventory> Inventory { get; set; }
    public DbSet<InventoryItem> InventoryItem { get; set; }
    public DbSet<Interaction> Interactions { get; set; }
    public DbSet<InteractiveMapLayer> InteractiveMapLayers { get; set; }
    public DbSet<Item> Item { get; set; }
    
    public DbSet<Map> Maps { get; set; }
    public DbSet<MapLayerSprite> MapLayerSprites { get; set; }
        
    public DbSet<Neighbourhood> Neighbourhoods { get; set; }
    
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerInteractions> PlayerInteractions { get; set; }
    
    public DbSet<SpriteAnimation> SpriteAnimations { get; set; }
    public DbSet<Sprite> Sprites { get; set; }
    public DbSet<StaticMapLayer> StaticMapLayers { get; set; }
    
    public DbSet<TileSheet> TileSheets { get; set; }
    public DbSet<Trigger> Triggers { get; set; }
    public DbSet<TriggerableEvent> TriggerableEvents { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Door>()
            .HasOne(door => door.InteractiveMapLayerOne)
            .WithMany()
            .HasForeignKey(door => door.InteractiveMapLayerOneId);

        modelBuilder.Entity<Door>()
            .HasOne(door => door.InteractiveMapLayerTwo)
            .WithMany()
            .HasForeignKey(door => door.InteractiveMapLayerTwoId);
        
        modelBuilder.Entity<Map>()
            .HasOne(map => map.BackgroundStaticLayer)
            .WithMany()
            .HasForeignKey(map => map.BackgroundStaticLayerId);

        modelBuilder.Entity<Map>()
            .HasOne(map => map.ForegroundStaticLayer)
            .WithMany()
            .HasForeignKey(map => map.ForegroundStaticLayerId);

        modelBuilder.Entity<Map>()
            .HasOne(map => map.BackgroundInteractiveLayer)
            .WithMany()
            .HasForeignKey(map => map.BackgroundInteractiveLayerId);

        modelBuilder.Entity<Map>()
            .HasOne(map => map.ForegroundInteractiveLayer)
            .WithMany()
            .HasForeignKey(map => map.ForegroundInteractiveLayerId);
    }
}