using Microsoft.AspNetCore.Mvc;

namespace Editor.Features.Assets.GetAsset;

public static class GetAssetEndpoint
{
    public static RouteGroupBuilder MapGetAssetEndpoint(this RouteGroupBuilder endpointGroupBuilder)
    {
        endpointGroupBuilder.MapGet("/{id}", HandleRequest);
        return endpointGroupBuilder;
    }
    
    private static async Task<IResult> HandleRequest([FromRoute] Guid id, GetAssetUseCase useCase, CancellationToken ct)
    {
        var assetDto = await useCase.Handle(id, ct);
        
        return assetDto == null 
            ? Results.NotFound() 
            : Results.Ok(new GetAssetResponse(assetDto));
    }
}