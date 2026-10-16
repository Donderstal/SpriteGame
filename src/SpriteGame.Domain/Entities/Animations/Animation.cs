using SpriteGame.Domain.Enums;

namespace SpriteGame.Domain.Entities.Animations;

public class Animation
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    public AnimationType Type { get; set; }
    public Direction Direction { get; set; }

    public ICollection<AnimationFrame> Frames { get; } = new List<AnimationFrame>();
}