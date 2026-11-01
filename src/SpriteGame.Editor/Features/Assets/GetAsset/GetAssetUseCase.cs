using SpriteGame.Domain.Dtos;
using SpriteGame.Domain.Entities.Assets;
using SpriteGame.Persistence.Repositories;
using SpriteGame.Shared.Services;

namespace Editor.Features.Assets.GetAsset;

public class GetAssetUseCase(
    FileStorageService fileStorageService,
    IEntityRepository<Asset> assetRepository    
) {
    public async Task<AssetDto?> Handle(Guid assetId, CancellationToken ct)
    {
        var assetEntity = await assetRepository.GetByIdAsync(assetId);
        if (assetEntity == null)
        {
            await Console.Error.WriteLineAsync($"Asset entity with id {assetId} not found.");
            return null;
        }

        string fileAsBase64;

        try
        {
            fileAsBase64 = await fileStorageService.GetFileAsBase64(assetEntity.Path, ct);
        }
        catch (FileNotFoundException)
        {
            await Console.Error.WriteLineAsync($"File {assetId} not found at path {assetEntity.Path}.");
            return null;
        }

        return new AssetDto(
            assetEntity.Id,
            assetEntity.Name,
            assetEntity.Type,
            fileAsBase64
        );
    }
}