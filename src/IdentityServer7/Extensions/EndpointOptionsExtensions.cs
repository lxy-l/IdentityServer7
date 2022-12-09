// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer7.Configuration;
using IdentityServer7.Hosting;
using static IdentityServer7.Constants;

namespace IdentityServer7.Extensions
{
    public static class EndpointOptionsExtensions
    {
        public static bool IsEndpointEnabled(this EndpointsOptions options, Endpoint endpoint)
        {
            return endpoint?.Name switch
            {
                EndpointNames.Authorize => options.EnableAuthorizeEndpoint,
                EndpointNames.CheckSession => options.EnableCheckSessionEndpoint,
                EndpointNames.DeviceAuthorization => options.EnableDeviceAuthorizationEndpoint,
                EndpointNames.Discovery => options.EnableDiscoveryEndpoint,
                EndpointNames.EndSession => options.EnableEndSessionEndpoint,
                EndpointNames.Introspection => options.EnableIntrospectionEndpoint,
                EndpointNames.Revocation => options.EnableTokenRevocationEndpoint,
                EndpointNames.Token => options.EnableTokenEndpoint,
                EndpointNames.UserInfo => options.EnableUserInfoEndpoint,
                _ => true
            };
        }
    }
}