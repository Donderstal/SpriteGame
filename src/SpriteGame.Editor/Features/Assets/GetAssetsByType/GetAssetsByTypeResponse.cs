using SpriteGame.Application.Dtos;

namespace Editor.Features.Assets.GetAssetsByType;

public record GetAssetsByTypeResponse(
    List<AssetDto> Assets    
);