using SpriteGame.Domain.Entities.PlayerData;

namespace SpriteGame.Domain.Entities.Interactability;

public class Interaction : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public ICollection<PlayerInteractions> RegisteredInteractions { get; } = new List<PlayerInteractions>();
}