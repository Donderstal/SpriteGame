using SpriteGame.Domain.Entities.Interactability;
using SpriteGame.Domain.Entities.Sprites;

namespace SpriteGame.Domain.Entities.Maps;

public class InteractiveMapLayer
{
    public Guid Id { get; set; }
    
    public Guid MapId { get; set; }
    public Map Map { get; set; } = null!;
    
    public ICollection<Sprite> Sprites { get; } = new List<Sprite>();
    public ICollection<Trigger> Triggers { get; } = new List<Trigger>();
    public ICollection<Door> Doors { get; } = new List<Door>();
}