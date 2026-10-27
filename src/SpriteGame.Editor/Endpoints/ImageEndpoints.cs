using Editor.UseCases.Interfaces;
using SpriteGame.Domain.Requests;

namespace Editor.Endpoints;

public static class ImageEndpoints
{
    public static IEndpointRouteBuilder MapImageEndpoints(this IEndpointRouteBuilder endpointBuilder)
    {
        var group = endpointBuilder.MapGroup("/images");

        group.MapPost("/",
            static async (InsertImageRequest request, IInsertImageUseCase useCase, CancellationToken ct) =>
            {
                var newId = await useCase.Handle(request);
        
                return Results.Ok(newId);
            });
        
        return endpointBuilder;
    }
}