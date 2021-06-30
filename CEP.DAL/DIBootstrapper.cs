using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CEP.Constants;
using CEP.Models.Configuration;

namespace CEP.DAL
{
    public static class DIBootstrapper
    {
        public static IServiceCollection InitDal(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new DbSettings();
            configuration.GetSection(ConfigurationConstants.DBSectionName).Bind(settings);

            services.AddDbContextPool<DbContext, CEPContext>(options =>
            {
                options.UseSqlServer(
                    settings.DefaultConnection,
                    b => b.MigrationsAssembly(settings.MigrationAsseblyName))
                    .ConfigureWarnings(builder =>
                    {
                        builder.Default(WarningBehavior.Ignore);
                    })
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();
            }, settings.DbPoolSize);

            return services;
        }
    }
}
