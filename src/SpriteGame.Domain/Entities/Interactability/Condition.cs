using SpriteGame.Domain.Enums;

namespace SpriteGame.Domain.Entities.Interactability;

public class Condition : IEntity
{
    public Guid Id { get; set; }
    
    public Guid? InteractionId { get; set; }
    public Interaction? Interaction { get; set; }
    
    public ConditionType ConditionType { get; set; }
}