using Microsoft.EntityFrameworkCore;
using MvcUnitTestDemo.Data;

namespace MvcUnitTestDemo.Tests.Data
{
    public class DbContextTestFixture : IDisposable
    {
        public ApplicationDbContext Context { get; private set; }

        public DbContextTestFixture()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=.\\SQLEXPRESS;Database=MvcUnitTestDemo_Tests;User Id=sa;Password=123456;MultipleActiveResultSets=true;TrustServerCertificate=True")
                .Options;

            Context = new ApplicationDbContext(options);

            // Ensure clean DB every run
            Context.Database.EnsureDeleted();
            Context.Database.Migrate();
        }

        public void Dispose()
        {
            // Optional: clean after all tests
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }

}
