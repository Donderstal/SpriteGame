namespace SpriteGame.Domain.Entities.Events;

public class Event
{
    public Guid Id { get; set; }
    
    public ICollection<EventScene> Scenes { get; } = new List<EventScene>();
}