// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer7.Extensions;
using Microsoft.Extensions.Primitives;
using IdentityServer7.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using IdentityModel;

namespace IdentityServer7.Endpoints.Results
{
    public class ProtectedResourceErrorResult : IEndpointResult
    {
        public string Error;
        public string ErrorDescription;

        public ProtectedResourceErrorResult(string error, string errorDescription = null)
        {
            Error = error;
            ErrorDescription = errorDescription;
        }

        public Task ExecuteAsync(HttpContext context)
        {
            context.Response.StatusCode = 401;
            context.Response.SetNoCache();

            if (Constants.ProtectedResourceErrorStatusCodes.ContainsKey(Error))
            {
                context.Response.StatusCode = Constants.ProtectedResourceErrorStatusCodes[Error];
            }

            if (Error == OidcConstants.ProtectedResourceErrors.ExpiredToken)
            {
                Error = OidcConstants.ProtectedResourceErrors.InvalidToken;
                ErrorDescription = "The access token expired";
            }

            var errorString = string.Format($"error=\"{Error}\"");
            if (ErrorDescription.IsMissing())
            {
                context.Response.Headers.Add(HeaderNames.WWWAuthenticate, new StringValues(new[] { "Bearer realm=\"IdentityServer\"", errorString }).ToString());
            }
            else
            {
                var errorDescriptionString = string.Format($"error_description=\"{ErrorDescription}\"");
                context.Response.Headers.Add(HeaderNames.WWWAuthenticate, new StringValues(new[] { "Bearer realm=\"IdentityServer\"", errorString, errorDescriptionString }).ToString());
            }

            return Task.CompletedTask;
        }
    }
}
