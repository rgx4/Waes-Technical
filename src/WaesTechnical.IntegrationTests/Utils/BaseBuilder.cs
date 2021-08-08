using Microsoft.EntityFrameworkCore;
using WaesTechnical.Domain.Models;
using WaesTechnical.Infrastructure.DataProvider;

namespace WaesTechnical.IntegrationTests.Infrastructure.Utils
{
    public class BaseBuilder
    {
        public DbContextOptions<WaesDbContext> ReturnContextOptionBuilder()
        {
            return new DbContextOptionsBuilder<WaesDbContext>()
                .UseInMemoryDatabase(databaseName: "WaesTest")
                .Options; 
        }

        public DataInput DataInputLeft()
        {
            return new DataInput()
            {
                Data = "SW50ZWdyYXRpb24gVGVzdHMgbGVmdA==",
            };
        }
        public DataInput DataInputRight()
        {
            return new DataInput()
            {
                Data = "SW50ZWdyYXRpb24gVGVzdHMgcmlnaHQ=",
            };
        }
        public DataInput DataInputWrong()
        {
            return new DataInput()
            {
                Data = "!!!!",
            };
        }
    }
}
