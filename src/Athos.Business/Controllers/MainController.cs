 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Athos.Domain.Notifications;
using Athos.Domain.Notifications.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Athos.Business.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotification _notifier;

        protected MainController(INotification notifier)
        {
            _notifier = notifier;

        }

        protected bool OperationValided()
        {
            return !_notifier.HaveNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperationValided())
            {
                return Ok(new
                {
                    success = true,
                    message = "Success",
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                message = _notifier.GetNotifications().Select(n => n.Message),
                data = result
            });

        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificationErrorModelInvalid(modelState);
            return CustomResponse();
        }

        protected void NotificationErrorModelInvalid(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifierError(errorMsg);
            }
        }

        protected void NotifierError(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }
    }
}
