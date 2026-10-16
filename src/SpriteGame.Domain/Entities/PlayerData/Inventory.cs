namespace SpriteGame.Domain.Entities.PlayerData;

public class Inventory : IEntity
{
    public Guid Id { get; set; }
    
    public Guid PlayerId { get; set; }
    public Player Player { get; set; } = null!;
    
    public ICollection<InventoryItem> InventoryItems { get; } = new List<InventoryItem>();
}