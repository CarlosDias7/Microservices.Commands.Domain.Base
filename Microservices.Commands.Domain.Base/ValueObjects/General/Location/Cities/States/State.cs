using System;
using System.Collections.Generic;

namespace Microservices.Commands.Domain.Base.ValueObjects.General.Location.Cities.States
{
    public class State : ValueObjectWithIdentifier<Guid>
    {
        public const short NameMaxLength = 60;

        public State()
        {
        }

        public int? Code { get; private set; }
        public string Initials { get; private set; }
        public string Name { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Name;
            yield return Code;
        }

        protected override void SetId(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                Notification.AddError(DomainGeneralValueObjectsNotificationMessages.State_Id_Invalid);
                return;
            }

            Id = id;
        }

        protected void SetInitials(string initials) => Initials = initials;

        private void SetCode(int code) => Code = code;

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Notification.AddError(DomainGeneralValueObjectsNotificationMessages.State_Name_Empty);
                return;
            }

            if (name.Length > NameMaxLength)
            {
                Notification.AddError(string.Format(DomainGeneralValueObjectsNotificationMessages.State_Name_MaxLengthOverflow, NameMaxLength));
                return;
            }

            Name = name;
        }
    }
}