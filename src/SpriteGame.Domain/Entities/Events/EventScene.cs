namespace SpriteGame.Domain.Entities.Events;

public class EventScene : IEntity
{
    public Guid Id { get; set; }
    public int Index { get; set; }
    
    public ICollection<EventSceneAnimation> Animations { get; } =  new List<EventSceneAnimation>();
}