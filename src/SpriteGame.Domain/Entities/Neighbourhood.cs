using SpriteGame.Domain.Entities.Assets;
using SpriteGame.Domain.Entities.Maps;

namespace SpriteGame.Domain.Entities;

public class Neighbourhood
{
    public Guid Id { get; set; }
    
    public Guid MusicId { get; set; }
    public Audio Music { get; set; } = null!;
    
    public required string Name { get; set; }

    public ICollection<Map> Maps { get; } = new List<Map>();
}