using SpriteGame.Application.Dtos;
using SpriteGame.Application.Mappers;
using SpriteGame.Application.Services;
using SpriteGame.Domain.Entities.Assets;
using SpriteGame.Persistence.Repositories;

namespace Editor.Features.Assets.GetAssetsByType;

public class GetAssetsByTypeUseCase(
    FileStorageService fileStorageService,
    IEntityRepository<Asset> assetRepository        
) {
    public async Task<List<AssetDto>> Handle(GetAssetsByTypeRequest useCase, CancellationToken ct)
    {
        List<AssetDto> assetDtos = [];
        
        var assetEntities = await assetRepository.GetByExpressionAsync(asset => asset.Type == useCase.AssetType);
        if (assetEntities.Count == 0)
            return assetDtos;

        foreach (var assetEntity in assetEntities)
        {
            var fileAsBase64 = string.Empty;
            try
            {
                fileAsBase64 = await fileStorageService.GetFileAsBase64(assetEntity.Path, ct);
            }
            catch (FileNotFoundException)
            {
                await Console.Error.WriteLineAsync($"File {assetEntity.Id} not found at path {assetEntity.Path}.");
            }

            if (fileAsBase64 == string.Empty)
                continue;
            
            assetDtos.Add(assetEntity.ToAssetDto(fileAsBase64));
        }

        return assetDtos;
    }
}