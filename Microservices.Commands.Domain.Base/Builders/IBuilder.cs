using Microservices.Commands.Domain.Base.Entities;

namespace Microservices.Commands.Domain.Base.Builders
{
    public interface IBuilder<out TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        TEntity Build();
    }
}