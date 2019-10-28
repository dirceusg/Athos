using System;
using System.Collections.Generic;
using System.Text;

namespace Athos.Domain.Notifications.Interfaces
{
    public interface INotification 
    {
        bool HaveNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notification);

    }
}
