using IdentityServer7.EntityFramework;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebIdentityServer.Extensions
{
    public static class IdentityServerConfig
    {
        public static void AddIdentityServerConfig(this IServiceCollection services,string connectionStr) 
        {
            var migrationsAssembly = typeof(IdentityServerConfig).Assembly.GetName().Name;

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })
                    .AddConfigurationStore(options =>
                    {
                        options.ConfigureDbContext = builder =>
                            builder.UseSqlServer(connectionStr,
                                sql => sql.MigrationsAssembly(migrationsAssembly));
                    })
                   .AddOperationalStore(options =>
                   {
                       options.ConfigureDbContext = builder =>
                           builder.UseSqlServer(connectionStr, sql =>
                               sql.MigrationsAssembly(migrationsAssembly));
                       options.EnableTokenCleanup = true;
                       options.TokenCleanupInterval = 3600;
                   })
                   //.AddInMemoryIdentityResources(Config.IdentityResources)
                   //.AddInMemoryApiScopes(Config.ApiScopes)
                   //.AddInMemoryClients(Config.Clients)
                   .AddAspNetIdentity<IdentityUser>();

            builder.AddDeveloperSigningCredential();

        }
    }
}
