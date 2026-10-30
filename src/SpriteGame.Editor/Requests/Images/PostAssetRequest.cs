using System.ComponentModel.DataAnnotations;
using SpriteGame.Domain.Enums;

namespace Editor.Requests.Images;

public record PostAssetRequest(
    [Required] IFormFile File,
    [Required] string Name,
    [Required] AssetType Type
);