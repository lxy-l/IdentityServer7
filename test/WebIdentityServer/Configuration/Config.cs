
using IdentityServer7;
using IdentityServer7.Models;
using IdentityServer7.Stores.Models;

namespace WebIdentityServer.Configuration
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
            };

        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            //指定受保护的Api资源（AddJwtBearer： options.Audience = "WebApi";如果不使用要将ValidateAudience=false）
            //能不能访问Api资源由Client AllowedScopes判断，Api内部权限由Api自己管理
            new ApiResource("WebApi", "IdentityClientAspNet API")
            {
                Scopes = { "read", "write"}
            }
        };
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
            {
               new ApiScope(name: "read",    displayName: "读取"),
               new ApiScope(name: "write", displayName: "写入"),
               new ApiScope(name: "api1", displayName: "WebApi资源"),
            };

        public static IEnumerable<Client> Clients => new Client[]
            {
                 new Client
                {
                    ClientId = "Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowOfflineAccess = true,//提供refresh_token
                   AllowedScopes = { "api1" }
                },
                new Client
                {
                    ClientId = "Client1",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowOfflineAccess = true,//提供refresh_token
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "read", "write"
                    }
                },
                new Client
                {
                    ClientId = "Client2",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowOfflineAccess = true,
                    AllowedScopes = {  "openid", "profile" }
                },
                 new Client
                {
                    ClientId = "Client3",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    //AllowOfflineAccess = true,
                    AllowedScopes = {  "openid", "profile","read" }
                },
            };
    }
}
