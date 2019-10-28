using Athos.Domain.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Athos.Domain.Notifications
{
    public class Notifier : INotification
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HaveNotification()
        {
            return _notifications.Any();
        }
    }
}
