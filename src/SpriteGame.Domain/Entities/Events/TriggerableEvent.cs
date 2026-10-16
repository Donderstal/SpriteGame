using SpriteGame.Domain.Entities.Interactability;

namespace SpriteGame.Domain.Entities.Events;

public class TriggerableEvent : IEntity
{
    public Guid Id { get; set; }
    
    public Guid EventId  { get; set; }
    public Event Event { get; set; } = null!;
    
    public Guid? ConditionId { get; set; }
    public Condition? Condition { get; set; }
    
    public EventTrigger EventTrigger { get; set; } = null!;
}