// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using AutoMapper;

namespace IdentityServer7.EntityFramework.Storage.Mappers;

/// <summary>
/// Extension methods to map to/from entity/model for persisted grants.
/// </summary>
public static class PersistedGrantMappers
{
    static PersistedGrantMappers()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddProfile<PersistedGrantMapperProfile>())
            .CreateMapper();
    }

    public static IMapper Mapper { get; }

    /// <summary>
    /// Maps an entity to a model.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    public static IdentityServer7.Stores.Models.PersistedGrant ToModel(this Entities.PersistedGrant entity)
    {
        return entity == null ? null : Mapper.Map<IdentityServer7.Stores.Models.PersistedGrant>(entity);
    }

    /// <summary>
    /// Maps a model to an entity.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    public static Entities.PersistedGrant ToEntity(this IdentityServer7.Stores.Models.PersistedGrant model)
    {
        return model == null ? null : Mapper.Map<Entities.PersistedGrant>(model);
    }

    /// <summary>
    /// Updates an entity from a model.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="entity">The entity.</param>
    public static void UpdateEntity(this IdentityServer7.Stores.Models.PersistedGrant model, Entities.PersistedGrant entity)
    {
        Mapper.Map(model, entity);
    }
}