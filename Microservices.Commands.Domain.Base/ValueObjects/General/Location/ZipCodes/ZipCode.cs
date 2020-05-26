using System.Collections.Generic;

namespace Microservices.Commands.Domain.Base.ValueObjects.General.Location.ZipCodes
{
    public abstract class ZipCode : ValueObject
    {
        protected ZipCode(string code)
        {
            SetCode(code);
        }

        public string Code { get; private set; }

        public void SetCode(string code)
        {
            if (!Validate(code))
            {
                Notification.AddError(DomainGeneralValueObjectsNotificationMessages.ZipCode_Code_Invalid);
                return;
            }

            Code = code;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
        }

        protected abstract bool Validate(string code);
    }
}