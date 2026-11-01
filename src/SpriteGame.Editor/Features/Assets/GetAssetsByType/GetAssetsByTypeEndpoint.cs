using Microsoft.AspNetCore.Mvc;

namespace Editor.Features.Assets.GetAssetsByType;

public static class GetAssetsByTypeEndpoint
{
    public static RouteGroupBuilder MapGetAssetsByTypeEndpoint(this RouteGroupBuilder endpointGroupBuilder)
    {
        endpointGroupBuilder.MapGet("/by-type", HandleRequest);
        return endpointGroupBuilder;
    }
    
    private static async Task<IResult> HandleRequest([FromBody] GetAssetsByTypeRequest request, GetAssetsByTypeUseCase useCase, CancellationToken ct)
    {
        var assetDtos = await useCase.Handle(request, ct);
        
        return Results.Ok(new GetAssetsByTypeResponse(assetDtos));
    }
}