using System.ComponentModel.DataAnnotations;

namespace SpriteGame.Domain.Requests;

public record InsertImageRequest(
    [Required] string Name,
    [Required] byte[] Data
);