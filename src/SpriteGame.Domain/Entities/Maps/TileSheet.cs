using SpriteGame.Domain.Entities.Assets;

namespace SpriteGame.Domain.Entities.Maps;

public class TileSheet
{
    public Guid Id { get; set; }
    
    public Guid ImageId { get; set; }
    public Image Image { get; set; } = null!;
    
    public required string Name { get; set; }
    public int TileCount { get; set; }
    public required int[] BlockedTiles { get; set; }
}