using Microservices.Commands.Domain.Base.ValueObjects.General.Location.Cities.States;
using System;
using System.Collections.Generic;

namespace Microservices.Commands.Domain.Base.ValueObjects.General.Location.Cities
{
    public class City : ValueObjectWithIdentifier<Guid>
    {
        public const short NameMaxLength = 60;

        public City(int? code, string name, State state)
        {
            SetCode(code);
            SetName(name);
            SetState(state);
        }

        public int? Code { get; private set; }
        public string Name { get; private set; }
        public State State { get; private set; }

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
                Notification.AddError(DomainGeneralValueObjectsNotificationMessages.City_Id_Invalid);
                return;
            }

            Id = id;
        }

        private void SetCode(int? code) => Code = code;

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Notification.AddError(DomainGeneralValueObjectsNotificationMessages.City_Name_Empty);
                return;
            }

            if (name.Length > NameMaxLength)
            {
                Notification.AddError(string.Format(DomainGeneralValueObjectsNotificationMessages.City_Name_MaxLengthOverflow, NameMaxLength));
                return;
            }

            Name = name;
        }

        private void SetState(State state)
        {
            if (state is null)
            {
                Notification.AddError(DomainGeneralValueObjectsNotificationMessages.City_State_Empty);
                return;
            }

            if (!state.IsValid())
            {
                Notification.AddError(state.Notification);
                return;
            }

            State = state;
        }
    }
}