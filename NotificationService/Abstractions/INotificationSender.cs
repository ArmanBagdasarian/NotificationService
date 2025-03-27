using NotificationService.Contracts.RequestModels;

namespace NotificationService.Abstractions
{
    public interface INotificationSender
    {
        public void Send(INotificationService notificationService, NotificationSendRequestModel model);
    }
}
