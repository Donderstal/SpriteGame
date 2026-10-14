using Microsoft.EntityFrameworkCore;
using SpriteGame.Domain.Entities;

namespace SpriteGame.Persistence;

public class SpriteGameDbContext(DbContextOptions<SpriteGameDbContext> options) : DbContext(options)
{
    public DbSet<Animation> Animations { get; set; }
    public DbSet<AnimationFrame> AnimationFrames { get; set; }
    
    public DbSet<SpriteAnimation> SpriteAnimations { get; set; }
    public DbSet<Sprite> Sprites { get; set; }
    public DbSet<SpriteImage> SpriteImages { get; set; }
}