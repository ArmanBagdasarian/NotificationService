using NotificationService.Contracts.ResponseModels;

namespace NotificationService.Abstractions
{
    public interface INotificationManageService
    {
        public List<NotificationResponseModel> GetAll();
    }
}
