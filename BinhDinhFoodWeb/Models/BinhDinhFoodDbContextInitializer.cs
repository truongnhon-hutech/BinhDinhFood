using Microsoft.EntityFrameworkCore;

namespace BinhDinhFood.Models;

public class BinhDinhFoodDbContextInitializer(BinhDinhFoodDbContext context, ILoggerFactory logger)
{
    private readonly BinhDinhFoodDbContext _context = context;
    private readonly ILogger _logger = logger.CreateLogger<BinhDinhFoodDbContextInitializer>();

    public async Task InitializeAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
            //await SeedDatabase();
        }
        catch (Exception exception)
        {
            _logger.LogError("Migration error {exception}", exception);
            throw;
        }
    }

    private Task SeedDatabase()
    {
        var sqlCommand = "";
        return _context.Database.ExecuteSqlRawAsync(sqlCommand);
    }
}
