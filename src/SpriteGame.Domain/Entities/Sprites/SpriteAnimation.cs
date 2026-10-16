using SpriteGame.Domain.Entities.Animations;

namespace SpriteGame.Domain.Entities.Sprites;

public class SpriteAnimation : IEntity
{
    public Guid Id { get; set; }
    
    public Guid SpriteId { get; set; }
    public Sprite Sprite { get; set; } = null!;
    
    public Guid AnimationId { get; set; }
    public Animation Animation { get; set; } = null!;
}