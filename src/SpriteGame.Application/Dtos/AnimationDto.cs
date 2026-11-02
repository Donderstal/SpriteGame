using SpriteGame.Domain.Enums;

namespace SpriteGame.Application.Dtos;

public record AnimationDto(
    Guid Id,
    
    string Name,
    AnimationType Type,
    Direction Direction,
    
    List<AnimationFrameDto> Frames
);