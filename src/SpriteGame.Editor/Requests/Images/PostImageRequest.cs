using System.ComponentModel.DataAnnotations;

namespace Editor.Requests.Images;

public record PostImageRequest(
    [Required] IFormFile File
);