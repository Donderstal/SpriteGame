using Microsoft.AspNetCore.Mvc;

namespace Editor.Features.Assets.DeleteAsset;

public static class DeleteAssetEndpoint
{
    public static RouteGroupBuilder MapDeleteAssetEndpoint(this RouteGroupBuilder endpointGroupBuilder)
    {
        endpointGroupBuilder.MapDelete("/{id}", HandleRequest);
        return endpointGroupBuilder;
    }
    
    private static async Task<IResult> HandleRequest([FromRoute] Guid id, DeleteAssetUseCase useCase, CancellationToken ct)
    {
        var deletedFile = await useCase.Handle(id, ct);
        
        return deletedFile 
            ? Results.Ok()
            : Results.NotFound();
    }
}