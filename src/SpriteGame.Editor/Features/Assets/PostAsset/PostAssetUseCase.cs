using SpriteGame.Domain.Entities.Assets;
using SpriteGame.Persistence.Repositories;
using SpriteGame.Shared.Exceptions;
using SpriteGame.Shared.Services;

namespace Editor.Features.Assets.PostAsset;

public class PostAssetUseCase(
    FileStorageService fileStorageService,
    IEntityRepository<Asset> assetRepository
) {
    public async Task<Guid> Handle(PostAssetRequest request, CancellationToken ct)
    {
        string filePath;
        try
        {
            filePath = await WriteFileToStorage(request, ct);
        }
        catch (FileStorageException e)
        {
            await Console.Error.WriteLineAsync($"Writing file {request.Name} to file storage failed: {e.Message}");
            throw;
        }

        Guid id;
        try
        {
            id =  await InsertAssetEntity(request, filePath, ct);
        }
        catch (Exception insertEntityException)
        {
            await Console.Error.WriteLineAsync($"Persisting Asset entity failed: {insertEntityException}");

            try
            {
                fileStorageService.DeleteFile(filePath);
            }
            catch (Exception cleanupException)
            {
                await Console.Error.WriteLineAsync($"Failed to remove file {filePath}: {cleanupException}");
            }

            throw;
        }

        return id;
    }

    private async Task<string> WriteFileToStorage(PostAssetRequest request, CancellationToken ct)
    {
        using var stream = new MemoryStream();
        await request.File.CopyToAsync(stream, ct);
        
        var extension = Path.GetExtension(request.File.FileName);
        
        return await fileStorageService.WriteFile(stream, request.Name, extension, ct);
    }

    private async Task<Guid> InsertAssetEntity(PostAssetRequest request, string filePath, CancellationToken ct)
    {
        var imageEntity = new Asset
        {
            Name = request.Name,
            Path = filePath,
            Type = request.Type
        };
        
        var id = assetRepository.Add(imageEntity);
        await assetRepository.SaveChangesAsync(ct);

        return id;
    }
}