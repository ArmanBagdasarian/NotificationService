using NotificationService.Abstractions;
using NotificationService.Contracts.RequestModels;

namespace NotificationService.Implementations
{
    public class EmailNotificationService : INotificationService
    {
        public void Dispose()
        {
            // release unmanaged resources
        }

        public bool Send(NotificationSendRequestModel model)
        {
            return true;
        }
    }
}
