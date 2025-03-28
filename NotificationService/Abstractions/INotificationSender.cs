using NotificationService.Contracts.RequestModels;

namespace NotificationService.Abstractions
{
    public interface INotificationSender
    {
        public bool Send(INotificationService notificationService, NotificationSendRequestModel model);
    }
}
