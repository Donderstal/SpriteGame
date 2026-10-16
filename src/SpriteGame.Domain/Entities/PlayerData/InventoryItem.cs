using SpriteGame.Domain.Entities.Interactability;

namespace SpriteGame.Domain.Entities.PlayerData;

public class InventoryItem
{
    public Guid Id { get; set; }
    
    public Guid InventoryId { get; set; }
    public Inventory Inventory { get; set; } = null!;
    
    public Guid ItemId { get; set; }
    public Item Item { get; set; } = null!;
}