namespace Microservices.Commands.Domain.Base.ValueObjects
{
    public abstract class ValueObjectWithIdentifier<TId> : ValueObject
        where TId : struct
    {
        public TId Id { get; protected set; }

        protected abstract void SetId(TId id);
    }
}