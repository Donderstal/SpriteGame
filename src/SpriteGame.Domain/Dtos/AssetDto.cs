using SpriteGame.Domain.Enums;

namespace SpriteGame.Domain.Dtos;

public record AssetDto(
    Guid Id,
    string Name,
    AssetType Type,
    string Base64
);