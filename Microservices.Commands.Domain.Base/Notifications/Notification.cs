using System.Collections.Generic;

namespace Microservices.Commands.Domain.Base.Notifications
{
    public class Notification : INotification
    {
        public Notification()
        {
            Errors = new List<string>();
        }

        public ICollection<string> Errors { get; }

        public void AddError(string error)
        {
            if (string.IsNullOrWhiteSpace(error)) return;
            Errors.Add(error);
        }

        public void AddError(IEnumerable<string> errors)
        {
            foreach (var error in errors) AddError(error);
        }

        public void AddError(INotification notification) =>
            AddError(notification?.Errors);

        public void AddError(IEnumerable<INotification> notifications)
        {
            foreach (var notification in notifications) AddError(notification);
        }

        public override string ToString() => string.Join(", ", Errors);
    }
}