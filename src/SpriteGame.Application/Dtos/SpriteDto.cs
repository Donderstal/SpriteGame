namespace SpriteGame.Application.Dtos;

public record SpriteDto(
    Guid Id,
    
    string SpriteSheetBase64,
    
    string Name,
    bool HasCollision,
    bool VerticallyAligned,
    
    int? BlockedAreaX,
    int? BlockedAreaY,
    int? BlockedAreaWidth,
    int? BlockedAreaHeight,
    
    List<AnimationDto> Animations
);