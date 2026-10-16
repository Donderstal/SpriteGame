using System.ComponentModel.DataAnnotations.Schema;

namespace SpriteGame.Domain.Entities.Maps;

public class Map : IEntity
{
    public Guid Id { get; set; }
    
    public Guid NeighbourhoodId { get; set; }
    public Neighbourhood Neighbourhood { get; set; } = null!;
    
    public Guid BackgroundStaticLayerId { get; set; }
    [ForeignKey(nameof(BackgroundStaticLayerId))]
    public StaticMapLayer BackgroundStaticLayer { get; set; } = null!;
    
    public Guid BackgroundInteractiveLayerId { get; set; }
    [ForeignKey(nameof(BackgroundInteractiveLayerId))]
    public InteractiveMapLayer BackgroundInteractiveLayer { get; set; } = null!;
    
    public Guid? ForegroundStaticLayerId { get; set; }
    [ForeignKey(nameof(ForegroundStaticLayerId))]
    public StaticMapLayer? ForegroundStaticLayer { get; set; }
    
    public Guid? ForegroundInteractiveLayerId { get; set; }
    [ForeignKey(nameof(ForegroundInteractiveLayerId))]
    public InteractiveMapLayer? ForegroundInteractiveLayer { get; set; }
    
    public required string Name { get; set; }
    public int Columns { get; set; }
    public int Rows { get; set; }
}