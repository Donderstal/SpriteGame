using SpriteGame.Domain.Entities.Sprites;

namespace SpriteGame.Domain.Entities.Assets;

public class Image
{
    public Guid Id { get; set; }
    public required byte[] File { get; set; }

    public ICollection<Sprite> Sprites { get; } = new List<Sprite>();
}