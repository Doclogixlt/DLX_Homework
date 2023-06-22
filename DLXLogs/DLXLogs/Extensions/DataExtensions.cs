using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DLXLogs.Extensions
{
    public static class DataExtensions
    {
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<LogsDbContext>();
            db.Database.Migrate();
            return app;
        }
    }
}
