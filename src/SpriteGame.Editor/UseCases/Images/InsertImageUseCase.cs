using Editor.Requests.Images;
using SpriteGame.Domain.Entities.Assets;
using SpriteGame.Persistence.Repositories;

namespace Editor.UseCases;

public class InsertImageUseCase(
    IEntityRepository<Image> imageRepository    
) {
    public async Task<Guid> Handle(PostImageRequest request, CancellationToken ct)
    {
        using var stream = new MemoryStream();
        await request.File.CopyToAsync(stream, ct);
        
        var imageEntity = new Image
        {
            Name = request.File.FileName,
            File = stream.ToArray()
        };
        
        var id = imageRepository.Add(imageEntity);
        await imageRepository.SaveChangesAsync();

        return id;
    }
}