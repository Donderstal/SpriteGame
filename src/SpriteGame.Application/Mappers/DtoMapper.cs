using SpriteGame.Application.Dtos;
using SpriteGame.Domain.Entities.Animations;
using SpriteGame.Domain.Entities.Assets;
using SpriteGame.Domain.Entities.Sprites;

namespace SpriteGame.Application.Mappers;

public static class DtoMapper
{
    public static AnimationDto ToAnimationDto(this Animation animation)
        => new(
            animation.Id, 
            animation.Name, 
            animation.Type, 
            animation.Direction,
            [.. animation.Frames.Select(frame => frame.ToAnimationFrameDto())]
        ); 
    
    public static AnimationFrameDto ToAnimationFrameDto(this AnimationFrame frame)
        => new(frame.Id, frame.X, frame.Y, frame.Width, frame.Height);
    
    public static AssetDto ToAssetDto(this Asset asset, string base64File) 
        => new(asset.Id, asset.Name, asset.Type, base64File);

    public static SpriteDto ToSpriteDto(this Sprite sprite, string spriteSheetBase64, List<AnimationDto> animations)
        => new(
            sprite.Id,
            spriteSheetBase64,
            sprite.Name,
            sprite.HasCollision,
            sprite.VerticallyAligned,
            sprite.BlockedAreaX,
            sprite.BlockedAreaY,
            sprite.BlockedAreaWidth,
            sprite.BlockedAreaHeight,
            animations
        );
}