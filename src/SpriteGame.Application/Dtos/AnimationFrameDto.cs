namespace SpriteGame.Application.Dtos;

public record AnimationFrameDto(
    Guid Id,
    
    int X,
    int Y,
    int Width,
    int Height
);