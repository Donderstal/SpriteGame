using SpriteGame.Domain.Entities.Interactability;
using SpriteGame.Domain.Entities.Maps;
using SpriteGame.Domain.Enums;

namespace SpriteGame.Domain.Entities.Sprites;

public class MapLayerSprite : IEntity
{
    public Guid Id { get; set; }
    
    public Guid SpriteId { get; set; }
    public Sprite Sprite { get; set; } = null!;
    
    public Guid SpriteLayerId { get; set; }
    public InteractiveMapLayer InteractiveMapLayer { get; set; } = null!;
    
    public Direction Direction { get; set; }
    public int Column { get; set; }
    public int Row { get; set; }
    public string? Name { get; set; }
    
    public List<Trigger> Triggers = [];
}