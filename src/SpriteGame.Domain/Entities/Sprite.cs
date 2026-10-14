namespace SpriteGame.Domain.Entities;

public class Sprite
{
    public Guid Id { get; set; }
    
    public Guid SpriteImageId { get; set; }
    public required SpriteImage SpriteImage { get; set; }
    
    public required string Name { get; set; }
    public bool Elevated { get; set; }
    public bool VerticallyAligned  { get; set; }

    public SpriteAnimation[] SpriteAnimations = [];
}