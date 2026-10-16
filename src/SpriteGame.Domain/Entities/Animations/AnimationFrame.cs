namespace SpriteGame.Domain.Entities.Animations;

public class AnimationFrame
{
    public Guid Id { get; set; }
    
    public Guid AnimationId { get; set; }
    public Animation Animation { get; set; } = null!;
    
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}