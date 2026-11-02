using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using SpriteGame.Application.Features.Sprites.GetSprite;

namespace SpriteGame.Application.Features;

public static class EndpointRoutBuilderExtensions
{
    public static void MapSharedEndpoints(this IEndpointRouteBuilder endpointBuilder)
    {
        var baseApiRoute = endpointBuilder.MapGroup("/api");

        baseApiRoute.AddAssetEndpoints();
    }

    private static void AddAssetEndpoints(this RouteGroupBuilder baseApiRoute)
    {
        var imagesGroup = baseApiRoute.MapGroup("/sprites");
        
        imagesGroup
            .MapGetSpriteEndpoint()
            .DisableAntiforgery();
    }
}