using SpriteGame.Domain.Entities.Assets;

namespace SpriteGame.Domain.Entities.Maps;

public class TileSheet : IEntity
{
    public Guid Id { get; set; }
    
    public Guid TileSheetImageId { get; set; }
    public Asset TileSheetImage { get; set; } = null!;
    
    public required string Name { get; set; }
    public int TileCount { get; set; }
    public required int[] BlockedTiles { get; set; }
}