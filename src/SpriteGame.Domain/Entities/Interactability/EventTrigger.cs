using SpriteGame.Domain.Entities.Events;

namespace SpriteGame.Domain.Entities.Interactability;

public class EventTrigger
{
    public Guid Id { get; set; }
    
    public Guid TriggerId  { get; set; }
    public Trigger Trigger { get; set; } = null!;
    
    public Guid TriggerableEventId  { get; set; }
    public TriggerableEvent TriggerableEvent { get; set; } = null!;
}