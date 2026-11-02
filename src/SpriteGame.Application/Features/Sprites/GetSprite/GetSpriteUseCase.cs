using SpriteGame.Application.Dtos;
using SpriteGame.Application.Mappers;
using SpriteGame.Application.Services;
using SpriteGame.Domain.Entities.Animations;
using SpriteGame.Domain.Entities.Sprites;
using SpriteGame.Persistence.Repositories;

namespace SpriteGame.Application.Features.Sprites.GetSprite;

public class GetSpriteUseCase(
    FileStorageService fileStorageService,
    IEntityRepository<Sprite> spriteRepository,
    IEntityRepository<Animation> animationRepository
) {
    public async Task<SpriteDto?> Handle(Guid spriteId, CancellationToken cancellationToken)
    {
        var sprite = await spriteRepository.GetByIdAsync(
            spriteId, 
            sprite => sprite.SpriteSheet,
            sprite => sprite.SpriteAnimations
        );
        
        if (sprite == null)
        {
            await Console.Error.WriteLineAsync($"Sprite entity with id {spriteId} not found.");
            return null;
        }

        var spriteSheetBase64 = await fileStorageService.GetFileAsBase64(sprite.SpriteSheet.Path, cancellationToken);
        if (string.IsNullOrEmpty(spriteSheetBase64))
        {
            await Console.Error.WriteLineAsync($"File {sprite.SpriteSheet.Id} not found at path {sprite.SpriteSheet.Path}.");
            return null;
        }

        var animationIds = sprite.SpriteAnimations.Select(spriteAnimation => spriteAnimation.Id);
        var animations = (
            await animationRepository.GetByExpressionAsync(animation => animationIds.Contains(animation.Id))
        ).Select(
            spriteAnimation => spriteAnimation.ToAnimationDto()
        ).ToList();

        return sprite.ToSpriteDto(spriteSheetBase64, animations);
    }
}