using SpriteGame.Domain.Enums;

namespace Editor.Features.Assets.GetAssetsByType;

public record GetAssetsByTypeRequest(
    AssetType AssetType    
);