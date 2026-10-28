using SpriteGame.Domain.Enums;

namespace SpriteGame.Domain.Entities.Assets;

public class Asset : IEntity
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    public required string MimeType { get; set; }
    public required string Path { get; set; }
    
    public AssetType Type { get; set; }
}