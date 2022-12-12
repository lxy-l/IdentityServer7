// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using AutoMapper;

using IdentityServer7.EntityFramework.Storage.Entities;

namespace IdentityServer7.EntityFramework.Storage.Mappers;

/// <summary>
/// Defines entity/model mapping for scopes.
/// </summary>
/// <seealso cref="AutoMapper.Profile" />
public class ScopeMapperProfile : Profile
{
    /// <summary>
    /// <see cref="ScopeMapperProfile"/>
    /// </summary>
    public ScopeMapperProfile()
    {
        CreateMap<Entities.ApiScopeProperty, KeyValuePair<string, string>>()
            .ReverseMap();

        CreateMap<Entities.ApiScopeClaim, string>()
            .ConstructUsing(x => x.Type)
            .ReverseMap()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));

        CreateMap<Entities.ApiScope, IdentityServer7.Storage.Models.ApiScope>(MemberList.Destination)
            .ConstructUsing(src => new IdentityServer7.Storage.Models.ApiScope())
            .ForMember(x => x.Properties, opts => opts.MapFrom(x => x.Properties))
            .ForMember(x => x.UserClaims, opts => opts.MapFrom(x => x.UserClaims))
            .ReverseMap();
    }
}