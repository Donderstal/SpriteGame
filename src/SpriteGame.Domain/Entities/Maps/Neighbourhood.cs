using SpriteGame.Domain.Entities.Assets;

namespace SpriteGame.Domain.Entities.Maps;

public class Neighbourhood : IEntity
{
    public Guid Id { get; set; }
    
    public Guid MusicId { get; set; }
    public Asset Music { get; set; } = null!;
    
    public required string Name { get; set; }

    public ICollection<Map> Maps { get; } = new List<Map>();
}