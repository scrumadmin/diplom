﻿using System.Linq.Expressions;
using Afisha.Domain.Entities.Abstractions;
using Afisha.Domain.Enums;
using Microsoft.EntityFrameworkCore.Query;

namespace Afisha.Domain.Interfaces.Repositories;
public interface IReadRepository<T, TKey>
    where T : EntityBase<TKey>
    where TKey : struct
{
    Task<T?> GetById(
        TKey id,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        TrackingType trackingType = TrackingType.NoTracking,
        CancellationToken cancellationToken = default);

    Task<T> GetByIdOrThrow(
        TKey id,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        TrackingType trackingType = TrackingType.NoTracking,
        CancellationToken cancellationToken = default);

    Task<T[]> Get(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        TrackingType trackingType = TrackingType.NoTracking,
        CancellationToken cancellationToken = default);
}