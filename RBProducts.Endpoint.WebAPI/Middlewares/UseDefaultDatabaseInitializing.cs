using Microsoft.EntityFrameworkCore;

namespace RBProducts.Endpoint.WebAPI.Middlewares
{
    public static class DefaultMigrateExtensions
    {
        public static async Task UseDefaultMigrate<T>(this WebApplication app) where T : DbContext
        {
            using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<T>();
                await context.Database.MigrateAsync();
            }
        }

    }
}
