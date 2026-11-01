using Microsoft.AspNetCore.Mvc;
using SpriteGame.Domain.Enums;

namespace Editor.Features.Assets.PostAsset;

public static class PostAssetEndpoint
{
    public static RouteGroupBuilder MapPostAssetEndpoint(this RouteGroupBuilder endpointGroupBuilder)
    {
        endpointGroupBuilder.MapPost("/", HandleRequest)
            .Accepts<PostAssetRequest>("multipart/form-data");
        
        return endpointGroupBuilder;
    }

    private static async Task<IResult> HandleRequest([FromForm] PostAssetRequest request, PostAssetUseCase useCase, CancellationToken ct)
    {
        if(!ValidateIncoming(request))
            return Results.BadRequest(
                $"Invalid contentType {request.File.ContentType} for assetType {request.Type.ToString()}." +
                $" Ensure wav or mp3 for audio and png for other images."
            );

        
        var newId = await useCase.Handle(request, ct);
        return Results.Ok(new PostAssetResponse(newId));
    }
    
    private static bool ValidateIncoming(PostAssetRequest request)
    {
        switch (request)
        {
            case { Type: not (AssetType.Music or AssetType.SoundEffect), File.ContentType: "image/png" }:
            case { Type: AssetType.Music or AssetType.SoundEffect, File.ContentType: ("audio/wav" or "audio/mp3") }:
                return true;
            default:
                return false;
        }
    }
}