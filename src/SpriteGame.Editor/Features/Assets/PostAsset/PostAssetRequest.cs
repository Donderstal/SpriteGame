using System.ComponentModel.DataAnnotations;
using SpriteGame.Domain.Enums;

namespace Editor.Features.Assets.PostAsset;

public record PostAssetRequest(
    [Required] IFormFile File,
    [Required] string Name,
    [Required] AssetType Type
);