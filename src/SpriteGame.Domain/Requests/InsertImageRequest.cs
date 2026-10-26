namespace SpriteGame.Domain.Requests;

public record InsertImageRequest(
    string Name,
    byte[] Data
);