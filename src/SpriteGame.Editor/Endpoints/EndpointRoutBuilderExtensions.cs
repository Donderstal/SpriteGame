using Editor.Endpoints.Assets;

namespace Editor.Endpoints;

public static class EndpointRoutBuilderExtensions
{
    public static void MapEndpoints(this IEndpointRouteBuilder endpointBuilder)
    {
        var baseApiRoute = endpointBuilder.MapGroup("/api");

        baseApiRoute.AddAssetEndpoints();
    }

    private static void AddAssetEndpoints(this RouteGroupBuilder baseApiRoute)
    {
        var imagesGroup = baseApiRoute.MapGroup("/assets");
        
        imagesGroup.MapPostAssetEndpoint();
        imagesGroup.DisableAntiforgery();
    }
}