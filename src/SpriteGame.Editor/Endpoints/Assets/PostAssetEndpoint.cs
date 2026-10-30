using Editor.Requests.Images;
using Editor.UseCases.Images;
using Microsoft.AspNetCore.Mvc;
using SpriteGame.Domain.Enums;

namespace Editor.Endpoints.Assets;

public static class PostAssetEndpoint
{
    public static void MapPostAssetEndpoint(this RouteGroupBuilder endpointGroupBuilder)
    {
        endpointGroupBuilder.MapPost("/", HandleRequest)
            .Accepts<PostAssetRequest>("multipart/form-data");
    }

    private static async Task<IResult> HandleRequest([FromForm] PostAssetRequest request, PostAssetUseCase useCase, CancellationToken ct)
    {
        if(!ValidateIncoming(request))
            return Results.BadRequest(
                $"Invalid contentType {request.File.ContentType} for assetType {request.Type.ToString()}." +
                $" Ensure png for {AssetType.Image} and wav or mp3 for {AssetType.Audio}."
            );

        
        var newId = await useCase.Handle(request, ct);
        return Results.Ok(newId);
    }
    
    private static bool ValidateIncoming(PostAssetRequest request)
    {
        switch (request)
        {
            case { Type: AssetType.Image, File.ContentType: not "image/png" }:
            case { Type: AssetType.Audio, File.ContentType: not ("audio/wav" or "audio/mp3") }:
                return false;
            default:
                return true;
        }
    }
}