// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using AutoMapper;

using IdentityServer7.Storage.Models;

namespace IdentityServer7.EntityFramework.Storage.Mappers;

/// <summary>
/// Defines entity/model mapping for API resources.
/// </summary>
/// <seealso cref="AutoMapper.Profile" />
public class ApiResourceMapperProfile : Profile
{
    /// <summary>
    /// <see cref="ApiResourceMapperProfile"/>
    /// </summary>
    public ApiResourceMapperProfile()
    {
        CreateMap<Entities.ApiResourceProperty, KeyValuePair<string, string>>()
            .ReverseMap();

        CreateMap<Entities.ApiResource, ApiResource>(MemberList.Destination)
            .ConstructUsing(src => new IdentityServer7.Storage.Models.ApiResource())
            .ForMember(x => x.ApiSecrets, opts => opts.MapFrom(x => x.Secrets))
            .ForMember(x=>x.AllowedAccessTokenSigningAlgorithms, opts => opts.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter, x=>x.AllowedAccessTokenSigningAlgorithms))
            .ReverseMap()
            .ForMember(x => x.AllowedAccessTokenSigningAlgorithms, opts => opts.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter, x => x.AllowedAccessTokenSigningAlgorithms));

        CreateMap<Entities.ApiResourceClaim, string>()
            .ConstructUsing(x => x.Type)
            .ReverseMap()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));

        CreateMap<Entities.ApiResourceSecret, Secret>(MemberList.Destination)
            .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
            .ReverseMap();

        CreateMap<Entities.ApiResourceScope, string>()
            .ConstructUsing(x => x.Scope)
            .ReverseMap()
            .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src));
    }
}