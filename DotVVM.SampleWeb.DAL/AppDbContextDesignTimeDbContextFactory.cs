using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

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
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(configuration.GetConnectionString(AppDbContextConstants.CONNECTION_STRING_DEFAULT_KEY));

            return new AppDbContext(builder.Options, configuration);
        }
    }
}