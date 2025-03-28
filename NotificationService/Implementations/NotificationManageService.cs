using NotificationService.Abstractions;
using NotificationService.Contracts.ResponseModels;
using NotificationService.Data;

namespace NotificationService.Implementations
{
    public class NotificationManageService : INotificationManageService
    {
        private readonly DataContext _context;

        public NotificationManageService(DataContext context)
        { 
          _context = context;
        }
        public List<NotificationResponseModel> GetAll()
        {
           
            return _context.Notifications.Select(n => new NotificationResponseModel
            {
                Id = n.Id,
                Destination = n.Destination,
                CreatedDate = n.CreatedDate,
                SendDate = n.SendDate,
                From = n.From,
                NotificationStatus = n.NotificationStatus,
                NotificationType = n.NotificationType,
                Subject = n.Subject,
                Text = n.Text
            }).ToList();
        }
    }
}
