using Editor.UseCases.Interfaces;
using SpriteGame.Domain.Entities.Assets;
using SpriteGame.Domain.Requests;
using SpriteGame.Persistence.Repositories;

namespace Editor.UseCases;

public class InsertImageUseCase(
    IEntityRepository<Image> imageRepository    
) : IInsertImageUseCase
{
    public async Task<Guid> Handle(InsertImageRequest useCase)
    {
        var imageEntity = new Image
        {
            Name = useCase.Name,
            File = useCase.Data,
        };
        
        var id = imageRepository.Add(imageEntity);
        await imageRepository.SaveChangesAsync();

        return id;
    }
}