using SpriteGame.Domain.Requests;

namespace Editor.UseCases.Interfaces;

public interface IInsertImageUseCase
{
    Task<Guid> Handle(InsertImageRequest useCase);
}