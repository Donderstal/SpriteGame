using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace SpriteGame.Application.Features.Sprites.GetSprite;

public static class GetSpriteEndpoint
{
    public static RouteGroupBuilder MapGetSpriteEndpoint(this RouteGroupBuilder endpointGroupBuilder)
    {
        endpointGroupBuilder.MapGet("/{id}", HandleRequest);
        return endpointGroupBuilder;
    }
    
    private static async Task<IResult> HandleRequest([FromRoute] Guid id, GetSpriteUseCase useCase, CancellationToken ct)
    {
        var spriteDto = await useCase.Handle(id, ct);
        
        return spriteDto == null 
            ? Results.NotFound() 
            : Results.Ok(new GetSpriteResponse(spriteDto));
    }
}