// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer7.EntityFramework.Storage.Entities;

namespace IdentityServer7.EntityFramework.Storage.TokenCleanup;

/// <summary>
/// Interface to model notifications from the TokenCleanup feature.
/// </summary>
public interface IOperationalStoreNotification
{
    /// <summary>
    /// Notification for persisted grants being removed.
    /// </summary>
    /// <param name="persistedGrants"></param>
    /// <returns></returns>
    Task PersistedGrantsRemovedAsync(IEnumerable<PersistedGrant> persistedGrants);

    /// <summary>
    /// Notification for device codes being removed.
    /// </summary>
    /// <param name="deviceCodes"></param>
    /// <returns></returns>
    Task DeviceCodesRemovedAsync(IEnumerable<DeviceFlowCodes> deviceCodes);
}