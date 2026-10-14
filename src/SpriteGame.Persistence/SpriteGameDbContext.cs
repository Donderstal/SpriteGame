using Microsoft.EntityFrameworkCore;
using SpriteGame.Domain.Entities;

namespace SpriteGame.Persistence;

public class SpriteGameDbContext(DbContextOptions<SpriteGameDbContext> options) : DbContext(options)
{
    public DbSet<SpriteImage> SpriteImages { get; set; }
}