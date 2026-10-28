using Editor.Requests.Images;
using Editor.UseCases.Images;
using Microsoft.AspNetCore.Mvc;

namespace Editor.Endpoints.Images;

public static class PostImageEndpoint
{
    public static void MapPostImageEndpoint(this RouteGroupBuilder endpointGroupBuilder)
    {
        endpointGroupBuilder.MapPost("/", Handler)
            .Accepts<PostImageRequest>("multipart/form-data");
    }

    private static async Task<IResult> Handler([FromForm] PostImageRequest request, InsertImageUseCase useCase, CancellationToken ct)
    {
        var newId = await useCase.Handle(request, ct);
        return Results.Ok(newId);
    }
}