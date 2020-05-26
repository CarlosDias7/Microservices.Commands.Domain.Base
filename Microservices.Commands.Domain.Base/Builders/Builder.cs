﻿using Microservices.Commands.Domain.Base.Entities;

namespace Microservices.Commands.Domain.Base.Builders
{
    public abstract class Builder<TBuilder, TEntity, TId> : IBuilder<TEntity, TId>
        where TBuilder : Builder<TBuilder, TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        protected TId Id;

        public abstract TEntity Build();

        public TBuilder WithId(TId id)
        {
            Id = id;
            return (TBuilder)this;
        }
    }
}