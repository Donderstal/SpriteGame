using SpriteGame.Domain.Entities.Interactability;
using SpriteGame.Domain.Enums;

namespace SpriteGame.Domain.Entities.PlayerData;

public class PlayerInteractions : IEntity
{
    public Guid Id { get; set; }
    
    public Guid InteractionId { get; set; }
    public Interaction Interaction { get; set; } = null!;
    
    public Guid PlayerId { get; set; }
    public Player Player { get; set; } = null!;
    
    public InteractionResult Result { get; set; }
}