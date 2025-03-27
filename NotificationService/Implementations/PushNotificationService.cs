using NotificationService.Abstractions;
using NotificationService.Contracts.RequestModels;
using System.Resources;

namespace NotificationService.Implementations
{
    public class PushNotificationService : INotificationService
    {
        public void Dispose()
        {
            //release unmanaged resources
        }

        public bool Send(NotificationSendRequestModel model)
        {
            //call external service, if everything is ok, return true, otherwise false, and save error in logs
            return false;
        }
    }
}
