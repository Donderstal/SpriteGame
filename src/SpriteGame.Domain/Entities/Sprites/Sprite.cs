using SpriteGame.Domain.Entities.Assets;

namespace SpriteGame.Domain.Entities.Sprites;

public class Sprite : IEntity
{
    public Guid Id { get; set; }
    
    public Guid SpriteImageId { get; set; }
    public Asset Asset { get; set; } = null!;
    
    public required string Name { get; set; }
    public bool HasCollision { get; set; }
    public bool VerticallyAligned  { get; set; }
    
    public int? BlockedAreaX { get; set; }
    public int? BlockedAreaY { get; set; }
    public int? BlockedAreaWidth { get; set; }
    public int? BlockedAreaHeight { get; set; }

    public ICollection<SpriteAnimation> SpriteAnimations { get; } = new List<SpriteAnimation>();
}