using System.ComponentModel.DataAnnotations.Schema;
using SpriteGame.Domain.Entities.Assets;

namespace SpriteGame.Domain.Entities.Maps;

public class StaticMapLayer : IEntity
{
    public Guid Id { get; set; }
    
    public Guid MapId { get; set; }
    public Map Map { get; set; } = null!;
    
    public Guid ImageId { get; set; }
    public Image Image { get; set; } = null!;
    
    [Column(TypeName = "jsonb")]
    public required string BlockedAreas { get; set; }
}