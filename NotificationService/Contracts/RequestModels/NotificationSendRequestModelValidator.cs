using FluentValidation;
using NotificationService.Enums;

namespace NotificationService.Contracts.RequestModels
{
    public class NotificationSendRequestModelValidator : AbstractValidator<NotificationSendRequestModel>
    {
        public NotificationSendRequestModelValidator()
        {
            RuleFor(p => p.Destination).NotNull().NotEmpty().WithMessage("Destination could not be empty");
            RuleFor(p => p.NotificationType).IsInEnum().WithMessage("Unknown modification channel");
        }
    }
}
