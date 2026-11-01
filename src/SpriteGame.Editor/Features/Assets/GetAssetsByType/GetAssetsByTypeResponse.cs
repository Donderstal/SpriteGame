using SpriteGame.Domain.Dtos;

namespace Editor.Features.Assets.GetAssetsByType;

public record GetAssetsByTypeResponse(
    List<AssetDto> Assets    
);