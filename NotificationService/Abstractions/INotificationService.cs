using NotificationService.Contracts.RequestModels;

namespace NotificationService.Abstractions
{
    public interface INotificationService:IDisposable
    {
        public bool Send(NotificationSendRequestModel model);
    }
}
