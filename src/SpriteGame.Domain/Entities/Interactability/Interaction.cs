using SpriteGame.Domain.Entities.PlayerData;

namespace SpriteGame.Domain.Entities.Interactability;

public class Interaction
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public ICollection<PlayerInteractions> RegisteredInteractions { get; } = new List<PlayerInteractions>();
}