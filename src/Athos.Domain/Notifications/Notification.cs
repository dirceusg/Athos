﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Athos.Domain.Notifications
{
    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}
