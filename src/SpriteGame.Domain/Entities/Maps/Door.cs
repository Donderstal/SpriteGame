using System.ComponentModel.DataAnnotations.Schema;

namespace SpriteGame.Domain.Entities.Maps;

public class Door
{
    public Guid Id { get; set; }
    
    public Guid InteractiveMapLayerOneId { get; set; }
    [ForeignKey(nameof(InteractiveMapLayerOneId))]
    public InteractiveMapLayer InteractiveMapLayerOne { get; set; } = null!;
    
    public int InteractiveMapLayerOneColumn { get; set; }
    public int InteractiveMapLayerOneRow { get; set; }

    public Guid InteractiveMapLayerTwoId { get; set; }
    [ForeignKey(nameof(InteractiveMapLayerTwoId))]
    public InteractiveMapLayer InteractiveMapLayerTwo { get; set; } = null!;
    
    public int InteractiveMapLayerTwoColumn { get; set; }
    public int InteractiveMapLayerTwoRow { get; set; }
}