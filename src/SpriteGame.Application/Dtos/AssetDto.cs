using SpriteGame.Domain.Enums;

namespace SpriteGame.Application.Dtos;

public record AssetDto(
    Guid Id,
    
    string Name,
    AssetType Type,
    string Base64
);