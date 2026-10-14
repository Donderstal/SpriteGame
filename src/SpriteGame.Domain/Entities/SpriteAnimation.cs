namespace SpriteGame.Domain.Entities;

public class SpriteAnimation
{
    public Guid Id { get; set; }
    
    public Guid SpriteId { get; set; }
    public required Sprite Sprite { get; set; }
    
    public Guid AnimationId { get; set; }
    public required Animation Animation { get; set; }
}