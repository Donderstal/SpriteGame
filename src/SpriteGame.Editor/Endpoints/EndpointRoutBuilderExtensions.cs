using Editor.Endpoints.Images;

namespace Editor.Endpoints;

public static class EndpointRoutBuilderExtensions
{
    public static void MapEndpoints(this IEndpointRouteBuilder endpointBuilder)
    {
        var baseApiRoute = endpointBuilder.MapGroup("/api");

        baseApiRoute.AddImageEndpoints();
    }

    private static void AddImageEndpoints(this RouteGroupBuilder baseApiRoute)
    {
        var imagesGroup = baseApiRoute.MapGroup("/images");
        
        imagesGroup.MapPostImageEndpoint();
        imagesGroup.DisableAntiforgery();
    }
}