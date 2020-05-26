using Microservices.Commands.Domain.Base.Notifications;
using System.Linq;

namespace Microservices.Commands.Domain.Base.Entities
{
    public abstract class Entity<TId>
        where TId : struct
    {
        protected Entity(TId id)
        {
            SetId(id);
        }

        protected Entity()
        {
        }

        public TId Id { get; private set; }

        public INotification Notification { get; }

        public virtual bool IsValid() => Notification?.Errors?.Any() ?? true;

        protected abstract void SetId(TId id);
    }
}