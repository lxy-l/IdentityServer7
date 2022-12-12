// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer7.Models;
using IdentityServer7.Extensions;

namespace IdentityServer7.Storage
{
    // public just for testing
    public class QueryStringAuthorizationParametersMessageStore : IAuthorizationParametersMessageStore
    {
        public Task<string> WriteAsync(Message<IDictionary<string, string[]>> message)
        {
            var queryString = message.Data.FromFullDictionary().ToQueryString();
            return Task.FromResult(queryString);
        }

        public Task<Message<IDictionary<string, string[]>>> ReadAsync(string id)
        {
            var values = id.ReadQueryStringAsNameValueCollection();
            var msg = new Message<IDictionary<string, string[]>>(values.ToFullDictionary());
            return Task.FromResult(msg);
        }

        public Task DeleteAsync(string id)
        {
            return Task.CompletedTask;
        }
    }
}
