namespace SpriteGame.Domain.Entities.Assets;

public class Audio
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required byte[] File { get; set; }
}