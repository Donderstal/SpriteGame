namespace SpriteGame.Domain.Entities;

public class SpriteImage
{
    public Guid Id { get; set; }
    public required byte[] Image { get; set; }

    public List<Sprite> Sprites = [];
}