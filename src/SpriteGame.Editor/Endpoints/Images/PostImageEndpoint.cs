using Editor.Requests.Images;
using Editor.UseCases.Images;

namespace Editor.Endpoints.Images;

public static class PostImageEndpoint
{
    public static void MapPostImageEndpoint(this RouteGroupBuilder endpointGroupBuilder)
    {
        endpointGroupBuilder.MapPost("/", Handler);
    }

    private static async Task<IResult> Handler(PostImageRequest request, InsertImageUseCase useCase, CancellationToken ct)
    {
        var newId = await useCase.Handle(request, ct);
        return Results.Ok(newId);
    }
}