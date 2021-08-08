using Microsoft.EntityFrameworkCore;
using WaesTechnical.Infrastructure.DataProvider;

namespace WaesTechnical.IntegrationTests.Infrastructure.Utils
{
    public class BaseBuilder
    {
        public DbContextOptions<WaesDbContext> ReturnContextOptionBuilder()
        {
            return new DbContextOptionsBuilder<WaesDbContext>()
                .UseInMemoryDatabase(databaseName: "Waes")
                .Options; 
        }
    }
}
