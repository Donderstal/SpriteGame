using SpriteGame.Domain.Enums;

namespace SpriteGame.Domain.Entities.Interactability;

public class Item : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public ItemType ItemType { get; set; }
}