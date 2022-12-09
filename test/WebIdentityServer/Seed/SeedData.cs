using IdentityModel;
using IdentityServer7.EntityFramework.Storage.DbContexts;
using IdentityServer7.EntityFramework.Storage.Mappers;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;

using WebIdentityServer.Configuration;
using WebIdentityServer.Data;

namespace WebIdentityServer.Seed
{
    public static class SeedData
    {
        public static async Task EnsureSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            await scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();

            await scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.MigrateAsync();

            var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

            await context.Database.MigrateAsync();

            await CreateAspNetUser();

            await CreateClients();

            await CreateScopes();

            await CreateApiResources();

            await CreateIdentityResources();

            await context.SaveChangesAsync();

            async Task CreateAspNetUser()
            {
                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var alice = await userMgr.FindByNameAsync("alice");
                if (alice == null)
                {
                    alice = new IdentityUser
                    {
                        UserName = "alice",
                        Email = "AliceSmith@email.com",
                        EmailConfirmed = true,
                    };
                    var result = await userMgr.CreateAsync(alice, "Pass123$");
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = await userMgr.AddClaimsAsync(alice, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        });
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                }
                else
                {
                }

                var bob = await userMgr.FindByNameAsync("bob");
                if (bob == null)
                {
                    bob = new IdentityUser
                    {
                        UserName = "bob",
                        Email = "BobSmith@email.com",
                        EmailConfirmed = true
                    };
                    var result = await userMgr.CreateAsync(bob, "Pass123$");
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = await userMgr.AddClaimsAsync(bob, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Bob Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Bob"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim("location", "somewhere")
                        });
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                }
                else
                {
                }
            }

            async Task CreateClients()
            {
                if (!await context.Clients.AnyAsync())
                {
                    foreach (var item in Config.Clients)
                    {
                        await context.Clients.AddAsync(item.ToEntity());
                    }
                }
            }

            async Task CreateScopes()
            {
                if (!await context.ApiScopes.AnyAsync())
                {
                    foreach (var item in Config.ApiScopes)
                    {
                        await context.ApiScopes.AddAsync(item.ToEntity());
                    }
                }
            }

            async Task CreateApiResources()
            {
                if (!await context.ApiScopes.AnyAsync())
                {
                    foreach (var item in Config.ApiResources)
                    {

                        await context.ApiResources.AddAsync(item.ToEntity());
                    }
                }
            }

            async Task CreateIdentityResources()
            {
                if (!await context.ApiResources.AnyAsync())
                {
                    foreach (var item in Config.IdentityResources)
                    {
                        await context.IdentityResources.AddAsync(item.ToEntity());
                    }
                }
            }
        }
    }
}
