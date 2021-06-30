using CEP.Constants;
using CEP.Models.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CEP.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CEPContext>
    {
        public CEPContext CreateDbContext(string[] args)
        {
            var configuration =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var settings = new DbSettings();
            configuration.GetSection(ConfigurationConstants.DBSectionName).Bind(settings);

            var builder = new DbContextOptionsBuilder<CEPContext>();
            builder.UseSqlServer(settings.DefaultConnection, b => b.MigrationsAssembly(settings.MigrationAsseblyName));

            return new CEPContext(builder.Options);
        }
    }
}
