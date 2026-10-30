using SpriteGame.Domain.Constants;
using SpriteGame.Shared.Exceptions;

namespace SpriteGame.Shared.Services;

public class FileStorageService
{
    private readonly string? _storageRootPath = Environment.GetEnvironmentVariable(FileStorageConstants.StorageRootPathEnvVar);

    public async Task<string> WriteFile(MemoryStream memoryStream, string fileName, string extension, CancellationToken ct)
    {
        ValidateFileStoragePath();
        ValidateIncomingFile(memoryStream, fileName);
     
        var slug = Guid.NewGuid().ToString();
        var filePath = Path.Combine(_storageRootPath!, slug + extension);
        
        if (memoryStream.TryGetBuffer(out var segment))
        {
            try
            {
                await using var file = File.Create(filePath);
                await file.WriteAsync(segment.Array!, segment.Offset, segment.Count, ct);
            }
            catch (OperationCanceledException)
            {
                TryDeleteAfterFailedWrite(filePath);
                throw;
            }
            catch (Exception e)
            {
                TryDeleteAfterFailedWrite(filePath);
                throw new FileStorageException(e.Message, e);
            }
        }

        return filePath;
    }

    public void DeleteFile(string fileName)
    {
        try
        {
            File.Delete(fileName);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine($"Attempted to delete non-existing file {fileName} ");
        }
        catch (Exception e)
        {
            throw new FileStorageException(e.Message, e);
        }
    }
    
    private void TryDeleteAfterFailedWrite(string filePath)
    {
        try
        {
            DeleteFile(filePath);
        }
        catch (Exception cleanupException)
        {
            Console.Error.WriteLine(
                $"Failed to remove partial file {filePath}: {cleanupException}");
        }
    }

    private void ValidateFileStoragePath()
    {
        if (string.IsNullOrWhiteSpace(_storageRootPath))
            throw new FileStorageException("Storage root path is not defined");

        if (Directory.Exists(_storageRootPath!)) 
            return;
        
        try
        {
            Directory.CreateDirectory(_storageRootPath!);
        }
        catch (Exception e)
        {
            throw new FileStorageException(e.Message, e);
        }
    }

    private static void ValidateIncomingFile(MemoryStream memoryStream, string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new FileStorageException("File name is not defined");

        if (memoryStream == null || memoryStream.Length == 0)
            throw new FileStorageException($"Memory stream for incoming file is null or empty");
    }
}