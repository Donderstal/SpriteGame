using SpriteGame.Domain.Entities.Maps;
using SpriteGame.Domain.Entities.Sprites;
using SpriteGame.Domain.Enums;

namespace SpriteGame.Domain.Entities.Interactability;

public class Trigger : IEntity
{
    public Guid Id { get; set; }
    
    public Guid? MapLayerSpriteId { get; set; }
    public MapLayerSprite? MapLayerSprite { get; set; }
    
    public Guid? SpriteLayerId { get; set; }
    public InteractiveMapLayer? SpriteLayer { get; set; }
    
    public TriggerType Type { get; set; }
    public int? Column { get; set; }
    public int? Row { get; set; }

    public ICollection<EventTrigger> EventTriggers { get; } =  new List<EventTrigger>();
}