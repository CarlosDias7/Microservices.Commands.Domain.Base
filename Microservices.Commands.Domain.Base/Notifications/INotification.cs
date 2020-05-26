using System.Collections.Generic;

namespace Microservices.Commands.Domain.Base.Notifications
{
    public interface INotification
    {
        ICollection<string> Errors { get; }

        void AddError(IEnumerable<string> erros);

        void AddError(string erro);

        void AddError(INotification baseValidation);

        public void AddError(IEnumerable<INotification> baseValidation);

        string ToString();
    }
}