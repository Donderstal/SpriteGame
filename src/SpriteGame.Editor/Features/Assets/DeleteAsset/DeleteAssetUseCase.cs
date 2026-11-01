using SpriteGame.Domain.Entities.Assets;
using SpriteGame.Persistence.Repositories;
using SpriteGame.Shared.Services;

namespace Editor.Features.Assets.DeleteAsset;

public class DeleteAssetUseCase(
    FileStorageService fileStorageService,
    IEntityRepository<Asset> assetRepository    
) {
    public async Task<bool> Handle(Guid assetId, CancellationToken ct)
    {
        var assetEntity = await assetRepository.GetByIdAsync(assetId);
        if (assetEntity == null)
        {
            await Console.Error.WriteLineAsync($"Asset entity with id {assetId} not found.");
            return false;
        }
        
        try
        {
            fileStorageService.DeleteFile(assetEntity.Path);
        }
        catch (Exception)
        {
            await Console.Error.WriteLineAsync($"Failed to remove file {assetEntity.Path}.");
            return false;
        }
        
        assetRepository.Delete(assetEntity);
        await assetRepository.SaveChangesAsync(ct);
        return true;
    }
}