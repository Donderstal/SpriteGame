namespace SpriteGame.Domain.Entities.Assets;

public class Audio : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required byte[] File { get; set; }
}