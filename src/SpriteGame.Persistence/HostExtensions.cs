using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SpriteGame.Persistence;

public static class HostExtensions
{
    public static async Task<IHost> MigrateDbAsync(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        
        try
        {
            var context = services.GetRequiredService<SpriteGameDbContext>();
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred applying database migrations: {ex}.");
        }

        return app;
    }
}