// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


#pragma warning disable 1591

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace IdentityServer7.Stores.Stores.Serialization;

public class CustomContractResolver : DefaultJsonTypeInfoResolver
{
    public CustomContractResolver()
    {
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        options.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.WriteIndented = true;
        var a = base.GetTypeInfo(type, options);
        return base.GetTypeInfo(type, options);
    }

    public override string ToString()
    {
        return base.ToString();
    }
}