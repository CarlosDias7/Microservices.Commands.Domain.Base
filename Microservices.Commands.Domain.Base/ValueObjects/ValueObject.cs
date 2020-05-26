using Microservices.Commands.Domain.Base.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace Microservices.Commands.Domain.Base.ValueObjects
{
    public abstract class ValueObject
    {
        public INotification Notification { get; }

        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != GetType()) return false;

            var other = (ValueObject)obj;
            var thisValues = GetAtomicValues().GetEnumerator();
            var otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^
                    ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
             .Select(x => x != null ? x.GetHashCode() : 0)
             .Aggregate((x, y) => x ^ y);
        }

        public virtual bool IsValid() => Notification?.Errors?.Any() ?? true;

        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null)) return false;
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right) => !EqualOperator(left, right);

        protected abstract IEnumerable<object> GetAtomicValues();
    }
}