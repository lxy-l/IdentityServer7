// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using AutoMapper;

using IdentityServer7.Storage.Models;

namespace IdentityServer7.EntityFramework.Storage.Mappers;

/// <summary>
/// Defines entity/model mapping for persisted grants.
/// </summary>
/// <seealso cref="AutoMapper.Profile" />
public class PersistedGrantMapperProfile:Profile
{
    /// <summary>
    /// <see cref="PersistedGrantMapperProfile">
    /// </see>
    /// </summary>
    public PersistedGrantMapperProfile()
    {
        CreateMap<Entities.PersistedGrant, PersistedGrant>(MemberList.Destination)
            .ReverseMap();
    }
}