// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using AutoMapper;

namespace IdentityServer7.EntityFramework.Storage.Mappers;

/// <summary>
/// Extension methods to map to/from entity/model for identity resources.
/// </summary>
public static class IdentityResourceMappers
{
    static IdentityResourceMappers()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityResourceMapperProfile>())
            .CreateMapper();
    }

    public static IMapper Mapper { get; }

    /// <summary>
    /// Maps an entity to a model.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    public static IdentityServer7.Storage.Models.IdentityResource ToModel(this Entities.IdentityResource entity)
    {
        return entity == null ? null : Mapper.Map<IdentityServer7.Storage.Models.IdentityResource>(entity);
    }

    /// <summary>
    /// Maps a model to an entity.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    public static Entities.IdentityResource ToEntity(this IdentityServer7.Storage.Models.IdentityResource model)
    {
        return model == null ? null : Mapper.Map<Entities.IdentityResource>(model);
    }
}