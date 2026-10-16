using SpriteGame.Domain.Entities.Sprites;

namespace SpriteGame.Domain.Entities.PlayerData;

public class Player
{
    public Guid Id { get; set; }
    
    public Guid SpriteId { get; set; } 
    public Sprite Sprite { get; set; } = null!;
    
    public required string Name { get; set; }
}