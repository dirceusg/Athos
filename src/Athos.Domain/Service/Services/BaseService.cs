using Athos.Domain.Notifications;
using Athos.Domain.Notifications.Interfaces;
using Athos.Entity.entities;
using FluentValidation;
using FluentValidation.Results;

namespace Athos.Domain.Service.Services
{
    public abstract class BaseService
    {
        private readonly INotification _notifier;

        protected BaseService(INotification notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool RunValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }

    }
}
