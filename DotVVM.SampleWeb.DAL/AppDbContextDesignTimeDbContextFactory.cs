using Microsoft.EntityFrameworkCore.Design;

namespace DotVVM.SampleWeb.DAL
{
    /// <summary>
    /// Design time DbContext factory
    /// </summary>
    public class AppDbContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        /// <inheritdoc />
        public AppDbContext CreateDbContext(string[] args)
        {
            return new AppDbContextFactory().Create();
        }
    }
}