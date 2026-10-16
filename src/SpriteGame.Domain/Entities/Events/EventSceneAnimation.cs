using SpriteGame.Domain.Enums;

namespace SpriteGame.Domain.Entities.Events;

// TODO: Design a data structure for storing different types of EventSceneAnimation 
public class EventSceneAnimation
{
    public Guid Id { get; set; }
    
    public Guid EventSceneId { get; set; }
    public EventScene EventScene { get; set; } = null!;
    
    public EventSceneAnimationType Type { get; set; }
}